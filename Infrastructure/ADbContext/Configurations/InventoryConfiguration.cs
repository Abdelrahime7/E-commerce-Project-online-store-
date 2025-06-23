using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventory");
        
        builder.HasKey(i => i.Id);
        
        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd();
            
        builder.Property(i => i.ItemId)
            .HasColumnName("ItemId")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(i => i.ItemQuantity)
            .HasColumnName("ItemQuantity")
            .HasColumnType("int")
            .IsRequired();
            
        builder.HasIndex(i => i.ItemId)
            .HasDatabaseName("IX_Inventories_ItemId")
            .IsUnique(); 
    }
}