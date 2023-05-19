namespace MasterBlogger.Application.Contracts.ArticleCategory
{
    public class RenameArticleCategoryCommand : CreateArticleCategoryCommand
    {
        public long Id { get; set; }
    }
}
