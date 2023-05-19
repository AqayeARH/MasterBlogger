using _01.Framework.Infrastructure;

namespace MasterBlogger.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
    {
        /*
		List<ArticleCategory> GetList();

		void Create(ArticleCategory entity);

        ArticleCategory GetBy(long id);

        void Update(ArticleCategory entity);

        void Save();

        bool IsTitleExist(string title);
        */
    }
}
