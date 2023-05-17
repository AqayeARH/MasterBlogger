using System;
using System.Collections.Generic;
using MasterBlogger.Domain.ArticleAgg;
using MasterBlogger.Domain.ArticleCategoryAgg.Services;

namespace MasterBlogger.Domain.ArticleCategoryAgg
{
	public class ArticleCategory
	{
		public long Id { get; private set; }
		public string Title { get; private set; }
		public bool IsDeleted { get; private set; }
		public DateTime CreationDate { get; private set; }

        public ICollection<Article> Articles { get; private set; }


        private static void CheckTitleNotNull(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }
        }

        public ArticleCategory(string title)
		{
            CheckTitleNotNull(title);
            Title = title;
			IsDeleted = false;
			CreationDate = DateTime.Now;
            Articles = new List<Article>();
        }

        public void Rename(string title)
		{
            CheckTitleNotNull(title);
			Title = title;
		}

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
	}
}
