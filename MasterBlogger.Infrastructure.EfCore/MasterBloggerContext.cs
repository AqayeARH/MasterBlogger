using MasterBlogger.Domain.ArticleAgg;
using MasterBlogger.Domain.ArticleCategoryAgg;
using MasterBlogger.Domain.CommentAgg;
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
        public DbSet<Comment> Comments { get; set; }

		#endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Fluent Api Configuration

            var assembly = typeof(ArticleFluentApi).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

			/*
			//Article Category Fluent Api
			modelBuilder.ApplyConfiguration(new ArticleCategoryFluentApi());

            //Article Fluent Api
            modelBuilder.ApplyConfiguration(new ArticleFluentApi());

            //Comment Fluent Api
            modelBuilder.ApplyConfiguration(new CommentFluentApi());
			*/

            #endregion

            base.OnModelCreating(modelBuilder);
		}
	}
}
