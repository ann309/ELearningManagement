using ELearning.DAL;
using ELearning.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningApplication.Controllers
{
    public class UploadDownloadController : Controller
    {
        private readonly ELearningDBContext _context;

        public UploadDownloadController(ELearningDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            List<Upload> fileUploadModel = await _context.Uploads.ToListAsync(); ;
            ViewBag.Message = TempData["Message"];
            return View(fileUploadModel);
        }


        [HttpPost]
        public async Task<IActionResult> UploadToFileSystem(List<IFormFile> files, string description)
        {
            foreach (var file in files)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    var fileModel = new Upload
                    {
                        CreatedOn = DateTime.UtcNow,
                        FileType = file.ContentType,
                        Extension = extension,
                        Name = fileName,
                        Description = description,
                        FilePath = filePath
                    };
                    _context.Uploads.Add(fileModel);
                    _context.SaveChanges();
                }
            }

            TempData["Message"] = "File successfully uploaded to File System.";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        {
            var file = await _context.Uploads.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (file == null) return NotFound("File does not exist");
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, file.FileType, file.Name + file.Extension);
        }

        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {

            var file = await _context.Uploads.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (file == null) return NotFound("File does not exist"); ;
            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }
            _context.Uploads.Remove(file);
            _context.SaveChanges();
            TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from File System.";
            return RedirectToAction("Index");
        }
    }
}
