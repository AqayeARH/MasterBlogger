using MasterBlogger.Application.Contracts.Comment;
using System.Collections.Generic;
using _01.Framework.Infrastructure.UnitOfWork;
using MasterBlogger.Domain.CommentAgg;

namespace MasterBlogger.Application
{
    public class CommentApplication : ICommentApplication
    {
        #region Constractor Injection

        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public void AddNewComment(AddCommentCommand command)
        {
            _unitOfWork.BeginTran();
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(comment);
            _unitOfWork.CommitTran();
            //_commentRepository.Save();
        }

        public List<CommentViewModel> List()
        {
            return _commentRepository.GetList();
        }

        public void Confirm(long id)
        {
            var comment = _commentRepository.GetBy(id);
            if (comment != null)
            {
                _unitOfWork.BeginTran();
                comment.Confirm();
                _commentRepository.Update(comment);
                //_commentRepository.Save();
                _unitOfWork.CommitTran();
            }
        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.GetBy(id);
            if (comment != null)
            {
                _unitOfWork.BeginTran();
                comment.Cancel();
                _commentRepository.Update(comment);
                //_commentRepository.Save();
                _unitOfWork.CommitTran();
            }
        }
    }
}
