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
    public class FacultyDAL : IPersonDAL<Faculty>
    {
        private readonly ELearningDBContext _db;

        public FacultyDAL(ELearningDBContext entityRef)
        {
            _db = entityRef;
        }

        public async Task<Faculty> EditAsync(string id, Faculty faculty)
        { 
            Faculty facultyData = _db.Faculties.Where(u => u.Id == id).SingleOrDefault();
            facultyData.Age = faculty.Age;
            facultyData.PhoneNumber = faculty.PhoneNumber;
            facultyData.Address = faculty.Address;
            facultyData.FirstName = faculty.FirstName;
            facultyData.LastName = faculty.LastName;
            facultyData.Email = faculty.Email;
            facultyData.Gender = faculty.Gender;
            facultyData.Designation = faculty.Designation;
            facultyData.Subject = faculty.Subject;
            await _db.SaveChangesAsync();
            return facultyData;
        }

        public async Task<Faculty> GetDetailsAsync(string id)
        {

            Faculty faculty = await _db.Faculties.Where(x => x.Id == id).FirstOrDefaultAsync();
            return faculty;

        }

    }
}
