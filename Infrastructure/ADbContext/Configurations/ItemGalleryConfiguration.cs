using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configurations;

public class ItemGalleryConfiguration : IEntityTypeConfiguration<ItemGallery>
{
    public void Configure(EntityTypeBuilder<ItemGallery> builder)
    {
        builder.ToTable("ItemGallery");
        
        builder.HasKey(ig => ig.Id);
        
        builder.Property(ig => ig.Id)
            .ValueGeneratedOnAdd();
            
        builder.Property(ig => ig.ItemId)
            .HasColumnName("ItemId")
            .HasColumnType("int")
            .IsRequired();
            
        builder.Property(ig => ig.ImageLink)
            .HasColumnName("ImageLink")
            .HasColumnType("nvarchar")
            .HasMaxLength(500)
            .IsRequired();
            
        builder.HasIndex(ig => ig.ItemId)
            .HasDatabaseName("IX_ItemGallery_ItemId");
    }
}