using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Model.EntityTypeConfiguration.Concrete
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.UserName).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Role).IsRequired(true);
            builder.Property(x => x.Image).HasMaxLength(100).IsRequired(true);

            base.Configure(builder);
        }
    }
}
