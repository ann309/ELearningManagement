using ELearning.BLL.Interface;
using ELearning.DAL;
using ELearning.DAL.Interface;
using ELearning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL
{
    public class StudentBLL : IPersonBLL<Student>
    {
        private readonly IPersonDAL<Student> _studentDAL;

        public StudentBLL(IPersonDAL<Student> studentDAL)
        {
            _studentDAL = studentDAL;
        }



        public async Task<Student> EditAsync(string id, Student student)
        {
            var result = await _studentDAL.EditAsync(id, student);
            if (result != null) return result;
            else return null;
        }


        public async Task<Student> GetDetailsAsync(string id)
        {

            var result = await _studentDAL.GetDetailsAsync(id);
            if (result != null) return result;
            else return null;

        }

    }
}
