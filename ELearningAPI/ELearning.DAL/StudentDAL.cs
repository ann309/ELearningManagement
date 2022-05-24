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
    public class StudentDAL : IPersonDAL<Student>
    {
        private readonly ELearningDBContext _db;

        public StudentDAL(ELearningDBContext entityRef)
        {
            _db = entityRef;
        }

        public async Task<Student> EditAsync(string id, Student student)
        {
            Student studentData = _db.Students.Where(u => u.Id == id).SingleOrDefault();
            studentData.Age = student.Age;
            studentData.PhoneNumber = student.PhoneNumber;
            studentData.Address = student.Address;
            studentData.FirstName = student.FirstName;
            studentData.LastName = student.LastName;
            studentData.Email = student.Email;
            studentData.Gender = student.Gender;
            studentData.Class = student.Class;
            await _db.SaveChangesAsync();
            return studentData;
        }

        public async Task<Student> GetDetailsAsync(string id)
        {

            Student student = await _db.Students.Where(x => x.Id== id).FirstOrDefaultAsync();
            return student;

        }
    }
}
