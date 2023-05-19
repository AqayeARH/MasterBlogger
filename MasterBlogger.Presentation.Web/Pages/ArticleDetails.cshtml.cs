using MasterBlogger.Application.Contracts.Comment;
using MasterBlogger.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogger.Presentation.Web.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        #region Constractor Injection

        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;
        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        #endregion

        public ArticleQueryViewModel Article { get; set; }

        [BindProperty]
        public AddCommentCommand Command { get; set; }

        public IActionResult OnGet(long id)
        {
            Article = _articleQuery.GetDetailArticle(id);
            if (Article == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _commentApplication.AddNewComment(Command);

            return RedirectToPage("ArticleDetails", new { id = Command.ArticleId });
        }
    }
}
