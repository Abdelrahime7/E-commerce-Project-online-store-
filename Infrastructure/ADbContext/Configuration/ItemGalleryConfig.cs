using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class ItemGalleryConfig : IEntityTypeConfiguration<ItemGallery>
    {
        public void Configure(EntityTypeBuilder<ItemGallery> builder)
        {
            builder.ToTable("ItemGalleries");
            builder.HasKey(I => I.Id);

            builder.Property(I => I.ImageLink).HasMaxLength(500);
           


            builder.HasOne(I => I.Item).WithOne(i => i.ItemGallery).
                HasForeignKey<ItemGallery>(I => I.ItemID).OnDelete(DeleteBehavior.Restrict);
            ;



        }
    }

}

