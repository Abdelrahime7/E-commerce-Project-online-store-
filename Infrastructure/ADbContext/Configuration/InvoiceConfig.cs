using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(I => I.Id);

            builder.Property(I => I.Quantity);
            builder.Property(I => I.Price).HasPrecision(10, 2);
            builder.Property(I => I.Date);

            builder .HasOne(I=>I.Order).WithMany(O=>O.invoices).
                HasForeignKey(I => I.OrderID).OnDelete(DeleteBehavior.Restrict);
            ;

            builder .HasOne(I=>I.Item).WithMany().
                HasForeignKey( I=> I.ItmenID).OnDelete(DeleteBehavior.Restrict);
            ;


        }
    }

}

