using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(O => O.Id);

            builder.Property(O => O.Status).HasMaxLength(50);
            builder.Property(O => O.Total).HasPrecision(10, 2);

            builder.HasOne(O => O.Customer).WithMany().HasForeignKey(O => O.CustomerId).OnDelete(DeleteBehavior.Restrict);
            ;




        }
    }

}

