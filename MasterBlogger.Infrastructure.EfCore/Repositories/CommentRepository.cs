using MasterBlogger.Domain.CommentAgg;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MasterBlogger.Application.Contracts.Comment;
using Microsoft.EntityFrameworkCore;

namespace MasterBlogger.Infrastructure.EfCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        #region Constractor Injection

        private readonly MasterBloggerContext _context;
        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        #endregion

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
        }

        public List<CommentViewModel> GetAll()
        {
            return _context.Comments
                .Include(x => x.Article)
                .Select(x => new CommentViewModel
                {
                    ArticleTitle = x.Article.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Email = x.Email,
                    Id = x.Id,
                    Message = x.Message,
                    Name = x.Name,
                    Status = x.Status,
                    ArticleId = x.ArticleId
                }).ToList();
        }

        public Comment GetBy(long id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
