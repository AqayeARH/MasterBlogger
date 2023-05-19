namespace MasterBlogger.Domain.ArticleAgg.Services
{
    public interface IArticleValidationService
    {
        void CheckArticleTitleExist(string title);
    }
}
