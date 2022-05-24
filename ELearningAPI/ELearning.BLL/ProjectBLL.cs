using ELearning.BLL.Interface;
using ELearning.DAL.Interface;
using ELearning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL
{
    public class ProjectBLL : IOperationBLL<Project>
    {
        private readonly IOperationDAL<Project> _projectDAL;

        public ProjectBLL(IOperationDAL<Project> projectDAL)
        {
            _projectDAL = projectDAL;
        }
        public async Task<Project> CreateAsync(Project project)
        {
            var result = await _projectDAL.CreateAsync(project);
            if (result != null) return result;
            else return null;
        }

        public async Task<Project> DeleteAsync(int id)
        {
            var result = await _projectDAL.DeleteAsync(id);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Project>> DisplayAsync()
        {
            var result = await _projectDAL.DisplayAsync();
            if (result != null) return result;
            else return null;
        }

        public async Task<Project> EditAsync(int id,Project project)
        {
            var result = await _projectDAL.EditAsync(id,project);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Project>> SearchAsync(int id)
        {
            var result = await _projectDAL.SearchAsync(id);
            if (result != null) return result;
            else return null;
        }
    }
}
