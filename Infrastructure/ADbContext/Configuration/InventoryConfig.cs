using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class InventoryConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventories");
            builder.HasKey(I => I.Id);

            builder.Property(I => I.ItemQuantity);
            builder.Property(I => I.InventoryDevision);

            builder.HasOne(I => I.Item).WithOne(I => I.Inventory)
                .HasForeignKey<Inventory>(I => I.ItemID).OnDelete(DeleteBehavior.Restrict);
            ;


        }
    }

}

