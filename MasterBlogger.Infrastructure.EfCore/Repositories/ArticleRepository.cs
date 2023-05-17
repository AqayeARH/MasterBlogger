using MasterBlogger.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
