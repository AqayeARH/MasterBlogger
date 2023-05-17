using System;
using MasterBlogger.Domain.ArticleCategoryAgg.Exceptions;

namespace MasterBlogger.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        #region Constractor Injection

        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        #endregion
        public void CheckArticleTitleExist(string title)
        {
            if (_articleCategoryRepository.IsTitleExist(title))
            {
                throw new AlreadyRecordExistException("This Title Is Already Exist");
            }
        }
    }
}
