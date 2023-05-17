using System;
using System.Collections.Generic;
using System.Text;
using MasterBlogger.Application;
using MasterBlogger.Application.Contracts.ArticleCategory;
using MasterBlogger.Domain.ArticleCategoryAgg;
using MasterBlogger.Domain.ArticleCategoryAgg.Services;
using MasterBlogger.Infrastructure.EfCore;
using MasterBlogger.Infrastructure.EfCore.Repositories;
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

            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

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
