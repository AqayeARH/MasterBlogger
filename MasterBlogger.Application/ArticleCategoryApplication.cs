using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MasterBlogger.Application.Contracts.ArticleCategory;
using MasterBlogger.Domain.ArticleCategoryAgg;
using MasterBlogger.Domain.ArticleCategoryAgg.Services;

namespace MasterBlogger.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        #region Constractor Injection

        private readonly IArticleCategoryRepository _articleCategoryRepository;
        //private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        #endregion

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();

            //Map To Article Category View Model
            return articleCategories.Select(x => new ArticleCategoryViewModel()
            {
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Id = x.Id,
                Title = x.Title,
            }).ToList();
        }

        public void Create(CreateArticleCategoryCommand command)
        {
            var articleCategory = new ArticleCategory(command.Title);

            //Add Article Category
            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.Save();
        }

        public void Rename(RenameArticleCategoryCommand command)
        {
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);

            //The Operation Of Rename Of The Article Category
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.Save();
        }

        public RenameArticleCategoryCommand GetForRename(long id)
        {
            //Get Article Category For Show In Rename Page
            var articleCategory = _articleCategoryRepository.GetBy(id);

            if (articleCategory == null)
            {
                return null;
            }

            return new RenameArticleCategoryCommand
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };
        }

        public void Remove(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Remove();
            _articleCategoryRepository.Update(articleCategory);
            _articleCategoryRepository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Activate();
            _articleCategoryRepository.Update(articleCategory);
            _articleCategoryRepository.Save();
        }
    }
}
