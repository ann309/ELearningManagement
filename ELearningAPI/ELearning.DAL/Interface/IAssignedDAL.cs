using ELearning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Interface
{
    public interface IAssignedDAL
    {
        public Task<List<Assigned>> DisplayAsync();
        public Task<Assigned> CreateAsync(Assigned assignVal);
        public Task<Assigned> EditAsync(int id, Assigned assignVal);
        public Task<Assigned> DeleteAsync(int id);
        public Task<List<Assigned>> SearchAsync(int id);
        public Task<Assigned> EditAccessibleByStudentAsync(int id, Assigned assignVal);
    }
}
