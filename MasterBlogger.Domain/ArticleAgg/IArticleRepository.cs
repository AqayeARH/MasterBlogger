using System.Collections.Generic;
using _01.Framework.Infrastructure;
using MasterBlogger.Application.Contracts.Article;

namespace MasterBlogger.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        /*
        //Reference To The Contracts
        List<ArticleViewModel> GetList();

        void Create(Article entity);

        Article GetBy(long id);

        void Update(Article entity);

        bool IsArticleTitleExist(string title);

        void Save();
        */

        List<ArticleViewModel> GetList();
    }
}
