namespace MasterBlogger.Application.Contracts.Comment
{
    public class AddCommentCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public long ArticleId { get; set; }
    }
}
