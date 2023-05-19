using System.Collections.Generic;
using MasterBlogger.Application.Contracts.Comment;

namespace MasterBlogger.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Create(Comment entity);
        List<CommentViewModel> GetAll();
        Comment GetBy(long id);

        void Update(Comment entity);
        void Save();
    }
}
