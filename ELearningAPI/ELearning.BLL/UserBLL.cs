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
    public class UserBLL : IUserBLL<UserInformation>
    {
        private readonly IUserDAL<UserInformation> _userDAL;

        public UserBLL(IUserDAL<UserInformation> userDAL)
        {
            _userDAL = userDAL;
        }
        public async Task<UserInformation> DeleteAsync(string id)
        {
            var result= await _userDAL.DeleteAsync(id);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Student>> DisplayStudentAsync()
        {
            var result = await _userDAL.DisplayStudentAsync();
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Faculty>> DisplayFacultyAsync()
        {
            var result = await _userDAL.DisplayFacultyAsync();
            if (result != null) return result;
            else return null;
        }

        public async Task<UserInformation> EditAsync(string id,UserInformation user)
        {
            var result = await _userDAL.EditAsync(id,user);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<UserInformation>> SearchAsync(string userName)
        {
            var result = await _userDAL.SearchAsync(userName);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Upload>> MyUploads(string userName)
        {
            var result = await _userDAL.MyUploads(userName);
            if (result != null) return result;
            else return null;
        }
    }
}
