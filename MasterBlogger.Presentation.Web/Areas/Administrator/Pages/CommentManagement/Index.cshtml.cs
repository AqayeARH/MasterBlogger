using System.Collections.Generic;
using MasterBlogger.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogger.Presentation.Web.Areas.Administrator.Pages.CommentManagement
{
    public class IndexModel : PageModel
    {
        #region Constractor Injection

        private readonly ICommentApplication _commentApplication;
        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        #endregion

        public List<CommentViewModel> Comments { get; set; }

        public void OnGet()
        {
            Comments = _commentApplication.List();
        }

        //Handlers:
        public IActionResult OnPostConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("Index");
        }
    }
}
