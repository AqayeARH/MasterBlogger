using System.Collections.Generic;
using System.Linq;
using MasterBlogger.Domain.CommentAgg;
using MasterBlogger.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MasterBlogger.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        #region Constractor Injection

        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        #endregion

        public List<ArticleQueryViewModel> GetAllArticles()
        {
            return _context.Articles
                .Include(a => a.ArticleCategory)
                .Include(a => a.Comments)
                .Select(a => new ArticleQueryViewModel
                {
                    ArticleCategory = a.ArticleCategory.Title,
                    CreationDate = a.CreationDate.ToShortDateString(),
                    Id = a.Id,
                    ShortDescription = a.ShortDescription,
                    Title = a.Title,
                    Image = a.Image,
                    CommentCount = a.Comments.Count(c => c.Status == CommentStatuses.Confirmed)
                }).ToList();
        }

        public ArticleQueryViewModel GetDetailArticle(long id)
        {
            return _context.Articles
                .Include(a => a.ArticleCategory)
                .Select(a => new ArticleQueryViewModel
                {
                    ArticleCategory = a.ArticleCategory.Title,
                    CreationDate = a.CreationDate.ToShortDateString(),
                    Id = a.Id,
                    ShortDescription = a.ShortDescription,
                    Title = a.Title,
                    Image = a.Image,
                    Content = a.Content,
                    CommentCount = a.Comments.Count(c => c.Status == CommentStatuses.Confirmed),
                    Comments = MapCommentToCommentQueryVewModel(a.Comments.Where(c => c.Status == CommentStatuses.Confirmed))
                }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryViewModel> MapCommentToCommentQueryVewModel(IEnumerable<Comment> comments)
        {
            return comments.Select(c => new CommentQueryViewModel()
            {
                CreationDate =c.CreationDate.ToShortDateString(),
                Message = c.Message,
                Name = c.Name
            }).ToList();
        }
    }
}