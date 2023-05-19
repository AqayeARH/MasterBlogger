using MasterBlogger.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterBlogger.Infrastructure.EfCore.FluentApi
{
    public class ArticleFluentApi : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //Name Table In Database
            builder.ToTable("Articles");

            //Set Primary Key
            builder.HasKey(k => k.Id);

            //Set Properties
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(400);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Image);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.CreationDate);

            //Relations
            builder.HasOne(x => x.ArticleCategory)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.ArticleCategoryId);

            builder.HasMany(x => x.Comments).WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleId);
        }
    }
}
