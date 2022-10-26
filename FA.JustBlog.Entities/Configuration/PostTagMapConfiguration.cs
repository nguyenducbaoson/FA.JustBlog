using FA.JustBlog.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Entities.Configuration
{
    public class PostTagMapConfiguration : IEntityTypeConfiguration<PostTagMap>
    {
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            builder.HasKey(x => new { x.TagId, x.PostId });
            builder.HasOne(x => x.Post).WithMany(x => x.PostTagMaps).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Tag).WithMany(x => x.PostTagMaps).HasForeignKey(x => x.TagId);
        }
    }
}
