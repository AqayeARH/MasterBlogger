using System.Collections.Generic;
using MasterBlogger.Application.Contracts.Article;
using MasterBlogger.Domain.ArticleAgg;

namespace MasterBlogger.Application
{
    public class ArticleApplication : IArticleApplication
    {
        #region Constractor Injection

        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        #endregion

        public List<ArticleViewModel> List()
        {
            return _articleRepository.GetAll();
        }

        public void Create(CreateArticleCommand command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.ImagePath,
                command.Content,
                command.ArticleCategoryId);
            _articleRepository.Create(article);
            _articleRepository.Save();
        }

        public void Edit(EditArticleCommand command)
        {
            var article = _articleRepository.GetBy(command.Id);

            if (article != null)
            {
                article.Edit(command.Title, command.ShortDescription, command.ImagePath, command.Content,
                    command.ArticleCategoryId);

                _articleRepository.Update(article);
                _articleRepository.Save();
            }
        }

        public EditArticleCommand GetForEdit(long id)
        {
            var article = _articleRepository.GetBy(id);
            if (article == null)
            {
                return null;
            }

            return new EditArticleCommand()
            {
                ImagePath = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId,
                ShortDescription = article.ShortDescription,
                Id = article.Id,
                Title = article.Title
            };
        }

        public void Remove(long id)
        {
            var article = _articleRepository.GetBy(id);
            if (article != null)
            {
                article.Remove();
                _articleRepository.Update(article);
                _articleRepository.Save();
            }
        }

        public void Activate(long id)
        {
            var article = _articleRepository.GetBy(id);
            if (article != null)
            {
                article.Activate();
                _articleRepository.Update(article);
                _articleRepository.Save();
            }
        }
    }
}
