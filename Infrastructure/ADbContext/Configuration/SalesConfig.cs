using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class SalesConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");
            builder.HasKey(S => S.Id);

            builder.Property(S=> S.TotalFees).HasPrecision(10,2);

            builder.HasOne(S => S.Order).WithOne(O=>O.Sale).HasForeignKey<Sale>(S=>S.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            ;


        }
    }

}

