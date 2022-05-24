using ELearning.DAL.Interface;
using ELearning.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL
{
    public class UserDAL : IUserDAL<UserInformation>
    {
        private readonly ELearningDBContext _db;

        public UserDAL(ELearningDBContext entityRef)
        {
            _db = entityRef;
        }

        public async Task<UserInformation> DeleteAsync(string id)
        {
            UserInformation userInformation = await _db.Users.FirstOrDefaultAsync(model=> model.Id==id);
            var delUser = _db.Users.Remove(userInformation);
            await _db.SaveChangesAsync();
            return delUser.Entity;
           

        }

        public async Task<List<Student>> DisplayStudentAsync()
        {          
            var studentList = await _db.Students.ToListAsync();
            return studentList; 
        }

        public async Task<List<Faculty>> DisplayFacultyAsync()
        {
            var facultyList = await _db.Faculties.ToListAsync();
            return facultyList;
        }



        public async Task<UserInformation> EditAsync(string id,UserInformation userInformation)
        {
            var updateUser = _db.Users.Update(userInformation); 
            await _db.SaveChangesAsync();
            return updateUser.Entity;

        }

        public async  Task<List<UserInformation>> SearchAsync(string userName)
        {
            var user =await  _db.Users.Where(u => u.UserName.ToLower() == userName.ToLower()).ToListAsync();
            return user;
        }

        public async Task<List <Upload>> MyUploads(string userName)
        {
            var uploads = await _db.Uploads.Where(x => x.UploadedBy.ToLower() == userName.ToLower()).ToListAsync();
            return uploads;
        }

       
    }
}
