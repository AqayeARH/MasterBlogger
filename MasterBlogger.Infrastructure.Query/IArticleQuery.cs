using System.Collections.Generic;

namespace MasterBlogger.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryViewModel> GetAllArticles();
        ArticleQueryViewModel GetDetailArticle(long id);
    }
}
