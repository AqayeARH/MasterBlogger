using System.Collections.Generic;
using MasterBlogger.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogger.Presentation.Web.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class IndexModel : PageModel
    {
        #region Constractor Injection

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        #endregion

        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.List();
        }

        //Handlers:
        public IActionResult OnPostRemove(long id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostActivate(long id)
        {
            _articleCategoryApplication.Activate(id);
            return RedirectToPage("Index");
        }
    }
}
