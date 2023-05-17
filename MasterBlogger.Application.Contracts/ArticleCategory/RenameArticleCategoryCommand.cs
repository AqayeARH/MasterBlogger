using System;
using System.Collections.Generic;
using System.Text;

namespace MasterBlogger.Application.Contracts.ArticleCategory
{
    public class RenameArticleCategoryCommand : CreateArticleCategoryCommand
    {
        public long Id { get; set; }
    }
}
