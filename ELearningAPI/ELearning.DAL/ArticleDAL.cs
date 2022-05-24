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
    public class ArticleDAL : IOperationDAL<Articles>
    {
        private readonly ELearningDBContext _db;
        public ArticleDAL(ELearningDBContext db)
        {
            _db = db;
        }
        public async Task<Articles> CreateAsync(Articles article)
        {
            var articleVal = await _db.Articles.AddAsync(article);
            await _db.SaveChangesAsync();
            return articleVal.Entity;
        }

        public async Task<Articles> DeleteAsync(int id)
        {
            Articles article = await _db.Articles.FirstOrDefaultAsync(c => c.ID == id);
            var delArticle = _db.Articles.Remove(article);
            await _db.SaveChangesAsync();
            return delArticle.Entity;
        }

        public async Task<List<Articles>> DisplayAsync()
        {
            var articleList = await _db.Articles.ToListAsync();
            return articleList;
        }

        public async Task<Articles> EditAsync(int id, Articles article)
        {
            Articles updateArticle = _db.Articles.Where(x => x.ID == id).FirstOrDefault();
            updateArticle.Title = article.Title;
            updateArticle.Link = article.Link;
            await _db.SaveChangesAsync();
            return updateArticle;
        }

        public async Task<List<Articles>> SearchAsync(int id)
        {
            var articleVal = await _db.Articles.Where(p => p.ID == id).ToListAsync();
            return articleVal;
        }
    }
}
