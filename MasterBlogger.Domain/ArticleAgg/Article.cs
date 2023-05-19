using System;
using System.Collections.Generic;
using MasterBlogger.Domain.ArticleCategoryAgg;
using MasterBlogger.Domain.CommentAgg;

namespace MasterBlogger.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        public ICollection<Comment> Comments { get; private set; }

        protected Article()
        {

        }

        private static void Validation(string title, string shortDescription, string content, long articleCategoryId)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(shortDescription) || string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException();
            }

            if (articleCategoryId == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public Article(string title, string shortDescription, string image, string content, long articleCategoryId)
        {
            Validation(title, shortDescription, content, articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Comments = new List<Comment>();
        }

        public void Edit(string title, string shortDescription, string image, string content, long articleCategoryId)
        {
            Validation(title, shortDescription, content, articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
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
