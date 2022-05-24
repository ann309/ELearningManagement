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
    public class AssignedBLL : IAssignedBLL
    {
        private readonly IAssignedDAL _assignDAL;

        public AssignedBLL(IAssignedDAL assignDAL)
        {
            _assignDAL = assignDAL;
        }
        public async Task<Assigned> CreateAsync(Assigned assigned)
        {
            var result = await _assignDAL.CreateAsync(assigned);
            if (result != null) return result;
            else return null;
        }

        public async Task<Assigned> DeleteAsync(int id)
        {
            var result = await _assignDAL.DeleteAsync(id);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Assigned>> DisplayAsync()
        {
            var result = await _assignDAL.DisplayAsync();
            if (result != null) return result;
            else return null;
        }

        public async Task<Assigned> EditAsync(int id,Assigned assignedVal)
        {
            var result = await _assignDAL.EditAsync(id,assignedVal);
            if (result != null) return result;
            else return null;
        }

        public async Task<Assigned> EditAccessibleByStudentAsync(int id, Assigned assignVal)
        {

            var result = await _assignDAL.EditAccessibleByStudentAsync(id, assignVal);

            if (result != null) return result;
            else return null;
        }
        public async Task<List<Assigned>> SearchAsync(int id)
        {
            var result = await _assignDAL.SearchAsync(id);
            if (result != null) return result;
            else return null;
        }
    }
}
