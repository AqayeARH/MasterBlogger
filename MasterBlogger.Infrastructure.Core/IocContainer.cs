﻿using MasterBlogger.Application;
using MasterBlogger.Application.Contracts.Article;
using MasterBlogger.Application.Contracts.ArticleCategory;
using MasterBlogger.Domain.ArticleAgg;
using MasterBlogger.Domain.ArticleAgg.Services;
using MasterBlogger.Domain.ArticleCategoryAgg;
using MasterBlogger.Domain.ArticleCategoryAgg.Services;
using MasterBlogger.Infrastructure.EfCore;
using MasterBlogger.Infrastructure.EfCore.Repositories;
using MasterBlogger.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasterBlogger.Infrastructure.Core
{
    public class IocContainer
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            #region Article Category

            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

            #endregion

            #region Article

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleValidationService, ArticleValidationService>();

            #endregion

            #region Queries

            services.AddTransient<IArticleQuery, ArticleQuery>();

            #endregion

            #region Ef Db Context

            services.AddDbContext<MasterBloggerContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            #endregion
        }
    }
}
