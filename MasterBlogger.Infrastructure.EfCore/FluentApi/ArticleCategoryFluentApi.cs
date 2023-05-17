using System;
using System.Collections.Generic;
using System.Text;
using MasterBlogger.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterBlogger.Infrastructure.EfCore.FluentApi
{
	public class ArticleCategoryFluentApi : IEntityTypeConfiguration<ArticleCategory>
	{
		public void Configure(EntityTypeBuilder<ArticleCategory> builder)
		{
			//Name Table In Database
			builder.ToTable("ArticleCategories");

			//Set PrimaryKey
			builder.HasKey(k => k.Id);

			//Set Properties
			builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
			builder.Property(x => x.IsDeleted);
			builder.Property(x => x.CreationDate);

            //Relations
            builder.HasMany(x => x.Articles)
                .WithOne(x => x.ArticleCategory)
                .HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}
