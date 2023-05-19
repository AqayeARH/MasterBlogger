using System.Collections.Generic;
using _01.Framework.Infrastructure.UnitOfWork;
using MasterBlogger.Application.Contracts.Article;
using MasterBlogger.Domain.ArticleAgg;

namespace MasterBlogger.Application
{
    public class ArticleApplication : IArticleApplication
    {
        #region Constractor Injection

        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleApplication(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public List<ArticleViewModel> List()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticleCommand command)
        {
            _unitOfWork.BeginTran();
            var article = new Article(command.Title, command.ShortDescription, command.ImagePath,
                command.Content,
                command.ArticleCategoryId);
            _articleRepository.Create(article);
            //_articleRepository.Save();
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticleCommand command)
        {
            var article = _articleRepository.GetBy(command.Id);

            if (article != null)
            {
                _unitOfWork.BeginTran();
                article.Edit(command.Title, command.ShortDescription, command.ImagePath, command.Content,
                    command.ArticleCategoryId);

                _articleRepository.Update(article);
                //_articleRepository.Save();
                _unitOfWork.CommitTran();
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
                _unitOfWork.BeginTran();
                article.Remove();
                _articleRepository.Update(article);
                //_articleRepository.Save();
                _unitOfWork.CommitTran();
            }
        }

        public void Activate(long id)
        {
            var article = _articleRepository.GetBy(id);
            if (article != null)
            {
                _unitOfWork.BeginTran();
                article.Activate();
                _articleRepository.Update(article);
                //_articleRepository.Save();
                _unitOfWork.CommitTran();
            }
        }
    }
}
