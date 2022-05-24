using ELearning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Interface
{
    public interface IPersonDAL<T>
    {


        public Task<T> EditAsync(string id, T t);
        public Task<T> GetDetailsAsync(string id);

    }
}
