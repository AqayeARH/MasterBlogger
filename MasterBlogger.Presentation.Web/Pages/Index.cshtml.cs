using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterBlogger.Infrastructure.Query;

namespace MasterBlogger.Presentation.Web.Pages
{
	public class IndexModel : PageModel
	{
        #region Constractor Injection

        private readonly IArticleQuery _articleQuery;
        public IndexModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        #endregion
		public List<ArticleQueryViewModel> Articles { get; set; }

        public void OnGet()
        {
            Articles = _articleQuery.GetAllArticles();
        }
	}
}
