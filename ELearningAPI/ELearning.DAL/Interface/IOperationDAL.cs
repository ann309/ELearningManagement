using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Interface
{
    public interface IOperationDAL<T>
    {
        public Task<List<T>> DisplayAsync();
        public Task<T> CreateAsync(T t);
        public Task<T> EditAsync(int id,T t);
        public Task<T> DeleteAsync(int id);
        public Task<List<T>> SearchAsync(int id);

    }
}
