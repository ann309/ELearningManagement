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
    public class FacultyBLL : IPersonBLL<Faculty>
    {
        private readonly IPersonDAL<Faculty> _facultyDAL;

        public FacultyBLL(IPersonDAL<Faculty> facultyDAL)
        {
            _facultyDAL = facultyDAL;
        }

        public async Task<Faculty> EditAsync(string id, Faculty faculty)
        {
            var result = await _facultyDAL.EditAsync(id, faculty);
            if (result != null) return result;
            else return null;
        }
        public async Task<Faculty> GetDetailsAsync(string id)
        {

            var result = await _facultyDAL.GetDetailsAsync(id);
            if (result != null) return result;
            else return null;

        }

    }
}
