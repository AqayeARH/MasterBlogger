using System.Collections.Generic;

namespace MasterBlogger.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        void AddNewComment(AddCommentCommand command);
        List<CommentViewModel> List();
        void Confirm(long id);
        void Cancel(long id);
    }
}
