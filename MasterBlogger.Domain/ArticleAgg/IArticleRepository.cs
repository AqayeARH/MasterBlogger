using System.Collections.Generic;
using MasterBlogger.Application.Contracts.Article;

namespace MasterBlogger.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        //Reference To The Contracts
        List<ArticleViewModel> GetAll();
        void Create(Article entity);
        Article GetBy(long id);
        void Update(Article entity);
        bool IsArticleTitleExist(string title);

        void Save();
    }
}
