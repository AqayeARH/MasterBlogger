using System;
using System.Collections.Generic;

namespace MasterBlogger.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> List();
        void Create(CreateArticleCommand command);
        void Edit(EditArticleCommand command);
        EditArticleCommand GetForEdit(long id);
        void Remove(long id);
        void Activate(long id);
    }
}
