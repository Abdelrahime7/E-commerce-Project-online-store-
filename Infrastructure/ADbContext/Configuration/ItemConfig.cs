using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(I => I.Id);

            builder.Property(I => I.Name).HasMaxLength(255);
            builder.Property(I => I.Description).HasMaxLength(255);
            builder.Property(I => I.Price).HasPrecision(10, 2);
            builder.Property(I => I.ExpireDate);
            builder.Property(I => I.ProdDate);
            builder.Property(I => I.UnitType);



        }
    }

}

