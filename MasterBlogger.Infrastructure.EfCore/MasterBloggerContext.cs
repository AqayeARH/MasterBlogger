using MasterBlogger.Domain.ArticleAgg;
using MasterBlogger.Domain.ArticleCategoryAgg;
using MasterBlogger.Infrastructure.EfCore.FluentApi;
using Microsoft.EntityFrameworkCore;

namespace MasterBlogger.Infrastructure.EfCore
{
	public class MasterBloggerContext : DbContext
	{
		public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) : base(options)
		{

		}

		#region Db Set

		public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

		#endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Fluent Api Configuration

			//Article Category Fluent Api
			modelBuilder.ApplyConfiguration(new ArticleCategoryFluentApi());

            //Article Fluent Api
            modelBuilder.ApplyConfiguration(new ArticleFluentApi());

            #endregion

            base.OnModelCreating(modelBuilder);
		}
	}
}
