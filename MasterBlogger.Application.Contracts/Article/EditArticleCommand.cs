﻿namespace MasterBlogger.Application.Contracts.Article
{
    public class EditArticleCommand:CreateArticleCommand
    {
        public long Id { get; set; }
    }
}
