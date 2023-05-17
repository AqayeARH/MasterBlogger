using MasterBlogger.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogger.Presentation.Web.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class RenameModel : PageModel
    {
        #region Constractor Injection

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public RenameModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        #endregion

        [BindProperty]
        public RenameArticleCategoryCommand ArticleCategory { get; set; }

        public IActionResult OnGet(long id)
        {
            ArticleCategory = _articleCategoryApplication.GetForRename(id);

            if (ArticleCategory == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _articleCategoryApplication.Rename(ArticleCategory);
            return RedirectToPage("Index");
        }
    }
}
