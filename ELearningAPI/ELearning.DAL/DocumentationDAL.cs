using ELearning.DAL.Interface;
using ELearning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL
{
    public class DocumentationDAL : IOperationDAL<Documentation>
    {
        private readonly ELearningDBContext _db;

        public DocumentationDAL(ELearningDBContext entityRef)
        {
            _db = entityRef;
        }
        
        public async Task<Documentation> CreateAsync(Documentation documentation)
        {
            var result =await _db.AddAsync(documentation);
            _db.SaveChanges();
            return result.Entity;
        }

        public async Task<Documentation> DeleteAsync(int id)
        {
            var documentation = await _db.Documentations.Where(d => d.ID == id).FirstOrDefaultAsync();
            _db.Documentations.Remove(documentation);
            _db.SaveChanges();
            return documentation;
        }

       
        public async Task<List<Documentation>> DisplayAsync()
        {
            var documentationList =await _db.Documentations.ToListAsync();
            return documentationList;
        }

        public async Task<Documentation> EditAsync(int id,Documentation documentationVal)
        {
            var updateDocumentation =  _db.Documentations.Where(x=>x.ID==id).FirstOrDefault();
            updateDocumentation.Title = documentationVal.Title;
            updateDocumentation.Title = documentationVal.Title;
            await _db.SaveChangesAsync();
            return updateDocumentation;
        }


        public async Task<List<Documentation>> SearchAsync(int id)
        {
            var documentation =await _db.Documentations.Where(d => d.ID == id).ToListAsync();
            return documentation;
        }

        
    }
}
