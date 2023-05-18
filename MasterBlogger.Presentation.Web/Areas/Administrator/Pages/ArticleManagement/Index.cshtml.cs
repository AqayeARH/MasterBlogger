using System.Collections.Generic;
using MasterBlogger.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogger.Presentation.Web.Areas.Administrator.Pages.ArticleManagement
{
    public class IndexModel : PageModel
    {
        #region Constractor Injection

        private readonly IArticleApplication _articleApplication;
        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        #endregion

        public List<ArticleViewModel> Articles { get; set; }

        public void OnGet()
        {
            Articles = _articleApplication.List();
        }

        //Handlers:
        public IActionResult OnPostRemove(long id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostActivate(long id)
        {
            _articleApplication.Activate(id);
            return RedirectToPage("Index");
        }
    }
}
