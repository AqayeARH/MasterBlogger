namespace MasterBlogger.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreationDate { get; set; }
        public string ArticleTitle { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
