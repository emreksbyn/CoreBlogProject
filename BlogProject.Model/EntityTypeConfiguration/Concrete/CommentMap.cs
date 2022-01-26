using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Model.EntityTypeConfiguration.Concrete
{
    public class CommentMap : BaseMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Text).IsRequired(true);
            // ComposetKey
            builder.HasKey(x => new { x.AppUserId, x.ArticleId });

            base.Configure(builder);
        }
    }
}
