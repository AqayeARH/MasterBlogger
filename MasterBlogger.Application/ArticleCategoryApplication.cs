using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _01.Framework.Infrastructure.UnitOfWork;
using MasterBlogger.Application.Contracts.ArticleCategory;
using MasterBlogger.Domain.ArticleCategoryAgg;
using MasterBlogger.Domain.ArticleCategoryAgg.Services;

namespace MasterBlogger.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        #region Constractor Injection

        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();

            //Map To Article Category View Model
            return articleCategories
                .OrderByDescending(x => x.Id)
                .Select(x => new ArticleCategoryViewModel()
                {
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Id = x.Id,
                    Title = x.Title,
                }).ToList();
        }

        public void Create(CreateArticleCategoryCommand command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);

            //Add Article Category
            _articleCategoryRepository.Create(articleCategory);
            //_articleCategoryRepository.Save();
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategoryCommand command)
        {
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);
            _unitOfWork.BeginTran();
            //The Operation Of Rename Of The Article Category
            articleCategory.Rename(command.Title);
            //_articleCategoryRepository.Save();
            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();
            articleCategory.Remove();
            _articleCategoryRepository.Update(articleCategory);
            _unitOfWork.CommitTran();
            //_articleCategoryRepository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            _unitOfWork.BeginTran();
            articleCategory.Activate();
            _articleCategoryRepository.Update(articleCategory);
            //_articleCategoryRepository.Save();
            _unitOfWork.CommitTran();
        }
    }
}
