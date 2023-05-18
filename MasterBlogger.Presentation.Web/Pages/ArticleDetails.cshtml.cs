using MasterBlogger.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogger.Presentation.Web.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        #region Constractor Injection

        private readonly IArticleQuery _articleQuery;
        public ArticleDetailsModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        #endregion

        public ArticleQueryViewModel Article { get; set; }

        public IActionResult OnGet(long id)
        {
            Article = _articleQuery.GetDetailArticle(id);
            if (Article == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
