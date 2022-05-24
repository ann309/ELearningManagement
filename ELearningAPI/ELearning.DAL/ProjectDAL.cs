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
    public class ProjectDAL : IOperationDAL<Project>
    {
        private readonly ELearningDBContext _db;

        public ProjectDAL(ELearningDBContext entityRef)
        {
            _db = entityRef;
        }
       
        public async Task<List<Project>> DisplayAsync()
        {
            List<Project> projectList = await _db.Projects.ToListAsync();
            await _db.SaveChangesAsync();
            return projectList;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            var projectVal = await _db.Projects.AddAsync(project);
            _db.SaveChanges();
            return projectVal.Entity;
        }

        public async Task<Project> EditAsync(int id,Project projectVal)
        {
            var updateProject = _db.Projects.Where(x=>x.ID==id).FirstOrDefault();
            updateProject.Title = projectVal.Title;
            updateProject.Description = projectVal.Description;
            await _db.SaveChangesAsync();
            return updateProject;
        }

        public async Task<Project> DeleteAsync(int id)
        {
            Project projectVal = await _db.Projects.Where(p => p.ID == id).FirstOrDefaultAsync();
            _db.Projects.Remove(projectVal);
            _db.SaveChanges();
            return projectVal;
        }

        public async Task<List<Project>> SearchAsync(int id)
        {
            var projectVal = await _db.Projects.Where(p => p.ID == id).ToListAsync();
            return projectVal;
        }

    }
}
