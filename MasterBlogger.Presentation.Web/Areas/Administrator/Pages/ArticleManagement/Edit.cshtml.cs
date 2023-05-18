using MasterBlogger.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using MasterBlogger.Application.Contracts.ArticleCategory;

namespace MasterBlogger.Presentation.Web.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        #region Constractor Injection

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        #endregion

        public List<SelectListItem> ArticleCategories { get; set; }

        [BindProperty]
        public EditArticleCommand Article { get; set; }

        public IActionResult OnGet(long id)
        {
            Article = _articleApplication.GetForEdit(id);
            if (Article == null)
            {
                return NotFound();
            }

            //Get Article Category List For Select
            ArticleCategories = _articleCategoryApplication.List()
                .Where(x => x.IsDeleted == false)
                .Select(x => new SelectListItem(x.Title, x.Id.ToString()))
                .ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            _articleApplication.Edit(Article);

            return RedirectToPage("Index");
        }
    }
}
