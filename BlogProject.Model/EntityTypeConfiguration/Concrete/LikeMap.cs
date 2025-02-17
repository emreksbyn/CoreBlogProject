﻿using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Model.EntityTypeConfiguration.Concrete
{
    public class LikeMap : BaseMap<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(x => new { x.AppUserId, x.ArticleId });

            base.Configure(builder);
        }
    }
}
