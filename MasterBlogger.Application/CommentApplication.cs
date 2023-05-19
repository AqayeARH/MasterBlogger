using MasterBlogger.Application.Contracts.Comment;
using System.Collections.Generic;
using MasterBlogger.Domain.CommentAgg;

namespace MasterBlogger.Application
{
    public class CommentApplication : ICommentApplication
    {
        #region Constractor Injection

        private readonly ICommentRepository _commentRepository;
        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        #endregion

        public void AddNewComment(AddCommentCommand command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(comment);
            _commentRepository.Save();
        }

        public List<CommentViewModel> List()
        {
            return _commentRepository.GetAll();
        }

        public void Confirm(long id)
        {
            var comment = _commentRepository.GetBy(id);
            if (comment != null)
            {
                comment.Confirm();
                _commentRepository.Update(comment);
                _commentRepository.Save();
            }
        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.GetBy(id);
            if (comment != null)
            {
                comment.Cancel();
                _commentRepository.Update(comment);
                _commentRepository.Save();
            }
        }
    }
}
