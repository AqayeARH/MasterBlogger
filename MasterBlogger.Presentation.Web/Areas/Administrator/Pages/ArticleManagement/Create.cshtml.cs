using System.Collections.Generic;
using System.Linq;
using MasterBlogger.Application.Contracts.Article;
using MasterBlogger.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterBlogger.Presentation.Web.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        #region Constractor Injection

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        #endregion

        public List<SelectListItem> ArticleCategories { get; set; }

        [BindProperty]
        public CreateArticleCommand Command { get; set; }

        public void OnGet()
        {
            //Get Article Category List For Select
            ArticleCategories = _articleCategoryApplication.List()
                .Where(x => x.IsDeleted == false)
                .Select(x => new SelectListItem(x.Title, x.Id.ToString()))
                .ToList();
        }

        public IActionResult OnPost()
        {

            _articleApplication.Create(Command);

            return RedirectToPage("Index");
        }
    }
}
