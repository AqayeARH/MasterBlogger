using System;
using System.Collections.Generic;
using System.Text;

namespace MasterBlogger.Application.Contracts.Article
{
    public class CreateArticleCommand
    {
        public long ArticleCategoryId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public string Content { get; set; }
    }
}
