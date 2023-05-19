using MasterBlogger.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterBlogger.Infrastructure.EfCore.FluentApi
{
    public class CommentFluentApi:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            //Name Table In Database
            builder.ToTable("Comments");

            //Set Primary Key
            builder.HasKey(x => x.Id);

            //Set Properties
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(350);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);

            //Relations
            builder.HasOne(x => x.Article).WithMany(x => x.Comments)
                .HasForeignKey(x => x.ArticleId);
        }
    }
}
