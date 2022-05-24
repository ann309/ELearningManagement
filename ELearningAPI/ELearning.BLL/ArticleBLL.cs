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
    public class ArticleBLL : IOperationBLL<Articles>
    {
        private readonly IOperationDAL<Articles> _articleDAL;

        public ArticleBLL(IOperationDAL<Articles> articleDAL)
        {
            _articleDAL = articleDAL;
        }
        public async Task<Articles> CreateAsync(Articles article)
        {
            var result = await _articleDAL.CreateAsync(article);
            if (result != null) return result;
            else return null;
        }

        public async Task<Articles> DeleteAsync(int id)
        {
            var result = await _articleDAL.DeleteAsync(id);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Articles>> DisplayAsync()
        {
            var result = await _articleDAL.DisplayAsync();
            if (result != null) return result;
            else return null;
        }

        public async Task<Articles> EditAsync(int id, Articles article)
        {
            var result = await _articleDAL.EditAsync(id, article);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Articles>> SearchAsync(int id)
        {
            var result = await _articleDAL.SearchAsync(id);
            if (result != null) return result;
            else return null;
        }
    }
}
