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
    public class CalenderBLL : IOperationBLL<Calender>
    {
        private readonly IOperationDAL<Calender> _calenderDAL;

        public CalenderBLL(IOperationDAL<Calender> calenderDAL)
        {
            _calenderDAL = calenderDAL;
        }
        public async Task<Calender> CreateAsync(Calender calender)
        {
            var result = await _calenderDAL.CreateAsync(calender);
            if (result != null) return result;
            else return null;
        }

        public async Task<Calender> DeleteAsync(int id)
        {
            var result = await _calenderDAL.DeleteAsync(id);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Calender>> DisplayAsync()
        {
            var result = await _calenderDAL.DisplayAsync();
            if (result != null) return result;
            else return null;
        }

        public async Task<Calender> EditAsync(int id, Calender calender)
        {
            var result = await _calenderDAL.EditAsync(id, calender);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Calender>> SearchAsync(int id)
        {
            var result = await _calenderDAL.SearchAsync(id);
            if (result != null) return result;
            else return null;
        }
    }
}
