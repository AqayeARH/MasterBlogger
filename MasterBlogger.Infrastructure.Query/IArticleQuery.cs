using System.Collections.Generic;
using System.Text;

namespace MasterBlogger.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryViewModel> GetAllArticles();
        ArticleQueryViewModel GetDetailArticle(long id);
    }
}
