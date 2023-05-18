using System;
using System.Collections.Generic;
using System.Text;
using MasterBlogger.Domain.ArticleCategoryAgg.Exceptions;

namespace MasterBlogger.Domain.ArticleAgg.Services
{
    public class ArticleValidationService: IArticleValidationService
    {
        #region Constractor Injection

        private readonly IArticleRepository _articleRepository;
        public ArticleValidationService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        #endregion

        public void CheckArticleTitleExist(string title)
        {
            if (_articleRepository.IsArticleTitleExist(title))
            {
                throw new AlreadyRecordExistException("Article Is Exist");
            }
        }
    }
}
