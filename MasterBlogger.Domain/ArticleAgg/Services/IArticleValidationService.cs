using System;
using System.Collections.Generic;
using System.Text;

namespace MasterBlogger.Domain.ArticleAgg.Services
{
    public interface IArticleValidationService
    {
        void CheckArticleTitleExist(string title);
    }
}
