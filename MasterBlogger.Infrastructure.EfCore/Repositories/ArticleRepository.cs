using MasterBlogger.Domain.ArticleAgg;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MasterBlogger.Application.Contracts.Article;
using Microsoft.EntityFrameworkCore;

namespace MasterBlogger.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        #region Constractor Injection

        private readonly MasterBloggerContext _context;
        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        #endregion

        public List<ArticleViewModel> GetAll()
        {
            return _context.Articles
                .Include(a => a.ArticleCategory)
                .Select(a => new ArticleViewModel()
                {
                    CategoryName = a.ArticleCategory.Title,
                    Title = a.Title,
                    CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Id = a.Id,
                    IsDeleted = a.IsDeleted,
                }).ToList();
        }

        public void Create(Article entity)
        {
            _context.Articles.Add(entity);
        }

        public Article GetBy(long id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Article entity)
        {
            _context.Articles.Update(entity);
        }

        public bool IsArticleTitleExist(string title)
        {
            return _context.Articles.Any(x => x.Title == title);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
