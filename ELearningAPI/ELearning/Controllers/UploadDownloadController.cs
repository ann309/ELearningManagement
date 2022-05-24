using ELearning.DAL;
using ELearning.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ELearning.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
   
    public class UploadDownloadController : ControllerBase
    {
        private readonly ELearningDBContext _context;
        private readonly UserManager<UserInformation> _userManager;

        public UploadDownloadController(ELearningDBContext context, UserManager<UserInformation> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> Display()
        {

            List<Upload> fileUploadModel = await _context.Uploads.ToListAsync();
            if (fileUploadModel != null)
            {
                return Ok(fileUploadModel);
            }
            else return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> UploadToFileSystem(List<IFormFile> files, string description,string userId)
        {
            foreach (var file in files)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
                bool basePathExists = Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);//check extension
                if (extension == ".exe") { return StatusCode(StatusCodes.Status451UnavailableForLegalReasons); }
                var user = await _userManager.FindByIdAsync(userId);
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
                        FilePath = filePath,
                        UploadedBy =user.UserName
                    };
                    _context.Uploads.AddAsync(fileModel);
                    await _context.SaveChangesAsync();
                    return Ok("successfully uploaded");
                }
                
            }
            return BadRequest();

            
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        {
            var file = await _context.Uploads.FirstOrDefaultAsync(x => x.ID == id);
            if (file == null) return NotFound("File does not exist");
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, file.FileType, file.Name + file.Extension);
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Faculty)]
        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {

            var file = await _context.Uploads.FirstOrDefaultAsync(x => x.ID == id);
            if (file == null) return NotFound("File does not exist"); ;
            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }
            _context.Uploads.Remove(file);
            await _context.SaveChangesAsync();
            return Ok("File deleted");
        }
    }
}



