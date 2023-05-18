namespace MasterBlogger.Domain.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidatorService
    {
        //Domain Service
        //----------------------

        void CheckArticleCategoryTitleExist(string title);
    }
}
