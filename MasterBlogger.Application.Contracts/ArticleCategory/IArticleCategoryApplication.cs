using System.Collections.Generic;

namespace MasterBlogger.Application.Contracts.ArticleCategory
{
	public interface IArticleCategoryApplication
	{
		List<ArticleCategoryViewModel> List();
        void Create(CreateArticleCategoryCommand command);
		void Rename(RenameArticleCategoryCommand command);
        RenameArticleCategoryCommand GetForRename(long id);
		void Remove(long id);
        void Activate(long id);
    }
}
