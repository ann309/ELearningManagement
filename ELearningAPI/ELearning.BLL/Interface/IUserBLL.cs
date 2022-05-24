using ELearning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Interface
{
    public interface IUserBLL<T>
    {
        public Task<List<Student>> DisplayStudentAsync();
        public Task<List<Faculty>> DisplayFacultyAsync();
        public Task<T> EditAsync(string id,T t);
        public Task<T> DeleteAsync(string id);
        public Task<List<T>> SearchAsync(string userName);
        public Task<List<Upload>> MyUploads(string userName);




    }
}
