using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(C => C.Id);
            builder.Property(C => C.Point);

            builder.HasOne(C => C.Person).WithOne(P => P.Customer).HasForeignKey<Customer>(C => C.PersonID)
                .OnDelete(DeleteBehavior.Restrict);
            ;
        }
    }

}

