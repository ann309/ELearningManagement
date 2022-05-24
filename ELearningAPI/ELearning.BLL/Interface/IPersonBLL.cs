using ELearning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Interface
{
    public interface IPersonBLL<T>
    {
        

        public Task<T> EditAsync(string id, T t);
        public Task<T> GetDetailsAsync(string id);


    }
}
