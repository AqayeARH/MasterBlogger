using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MasterBlogger.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MasterBlogger.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        #region Constractor Injection

        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        #endregion

        public List<ArticleQueryViewModel> GetAllArticles()
        {
            return _context.Articles
                .Include(a => a.ArticleCategory)
                .Select(a => new ArticleQueryViewModel
                {
                    ArticleCategory = a.ArticleCategory.Title,
                    CreationDate = a.CreationDate.ToShortDateString(),
                    Id = a.Id,
                    ShortDescription = a.ShortDescription,
                    Title = a.Title,
                    Image = a.Image
                }).ToList();
        }

        public ArticleQueryViewModel GetDetailArticle(long id)
        {
            return _context.Articles
                .Include(a => a.ArticleCategory)
                .Select(a => new ArticleQueryViewModel
                {
                    ArticleCategory = a.ArticleCategory.Title,
                    CreationDate = a.CreationDate.ToShortDateString(),
                    Id = a.Id,
                    ShortDescription = a.ShortDescription,
                    Title = a.Title,
                    Image = a.Image,
                    Content = a.Content
                }).FirstOrDefault(x=>x.Id == id);
        }
    }
}