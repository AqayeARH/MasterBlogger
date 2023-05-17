using MasterBlogger.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogger.Presentation.Web.Areas.Administrator.Pages.ArticleCategoryManagement
{
    [ValidateAntiForgeryToken]
    public class CreateModel : PageModel
    {
        #region Constractor Injection

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        #endregion

        [BindProperty]
        public CreateArticleCategoryCommand Command { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _articleCategoryApplication.Create(Command);
            return RedirectToPage("Index");
        }
    }
}
