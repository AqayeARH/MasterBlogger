using System.Collections.Generic;
using System.Linq;
using MasterBlogger.Domain.ArticleCategoryAgg;

namespace MasterBlogger.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        #region Constractor Injection

        private readonly MasterBloggerContext _context;
        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        #endregion

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public void Create(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
        }

        public ArticleCategory GetBy(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ArticleCategory entity)
        {
            _context.ArticleCategories.Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool IsTitleExist(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }
    }
}
