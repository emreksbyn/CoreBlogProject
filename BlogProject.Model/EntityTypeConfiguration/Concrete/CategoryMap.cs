using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Model.EntityTypeConfiguration.Concrete
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);

            base.Configure(builder);
        }
    }
}
