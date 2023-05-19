using System.Collections.Generic;
using _01.Framework.Infrastructure;
using MasterBlogger.Application.Contracts.Comment;

namespace MasterBlogger.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        /*
        void Create(Comment entity);

        List<CommentViewModel> GetList();

        Comment GetBy(long id);

        void Update(Comment entity);

        void Save();
        */

        List<CommentViewModel> GetList();
    }
}
