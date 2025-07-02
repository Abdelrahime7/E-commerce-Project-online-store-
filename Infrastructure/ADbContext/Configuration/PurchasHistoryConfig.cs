using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class PurchasHistoryConfig : IEntityTypeConfiguration<PurchaseHistory>

    {
        public void Configure(EntityTypeBuilder<PurchaseHistory> builder)
        {
            builder.ToTable("Purchases_History");
            builder.HasKey(P => P.Id);

           builder.HasOne(P=>P.Customer).WithMany(C=>C.PurchasesHistory)
                .HasForeignKey (P => P.CustomerId).OnDelete(DeleteBehavior.Restrict);
            ;

            builder.HasOne(P=>P.Order).WithOne(P=>P.PurchaseHistory).
                HasForeignKey<PurchaseHistory> (P=>P.OrderId).OnDelete(DeleteBehavior.Restrict);
            ;


        }
    }

}

