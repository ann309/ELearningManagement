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
    public class DocumentationBLL : IOperationBLL<Documentation>
    {
        private readonly IOperationDAL<Documentation> _documentationDAL;

        public DocumentationBLL(IOperationDAL<Documentation> documentationDAL)
        {
            _documentationDAL = documentationDAL;
        }
        public async Task<Documentation> CreateAsync(Documentation documentation)
        {
            var result = await _documentationDAL.CreateAsync(documentation);
            if (result != null) return result;
            else return null;
        }

        public async Task<Documentation> DeleteAsync(int id)
        {
            var result = await _documentationDAL.DeleteAsync(id);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Documentation>> DisplayAsync()
        {
            var result = await _documentationDAL.DisplayAsync();
            if (result != null) return result;
            else return null;
        }

        public async Task<Documentation> EditAsync(int id,Documentation documentation)
        {
            var result = await _documentationDAL.EditAsync(id,documentation);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Documentation>> SearchAsync(int id)
        {
            var result = await _documentationDAL.SearchAsync(id);
            if (result != null) return result;
            else return null;
        }
    }
}
