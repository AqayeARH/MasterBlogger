using System.Collections.Generic;

namespace MasterBlogger.Domain.ArticleCategoryAgg
{
	public interface IArticleCategoryRepository
	{
		List<ArticleCategory> GetAll();
		void Create(ArticleCategory entity);
        ArticleCategory GetBy(long id);
        void Update(ArticleCategory entity);
        void Save();
        bool IsTitleExist(string title);
    }
}
