using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class  ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");
            builder.HasKey(R => R.Id);

            builder.Property(R => R.Descreption).HasMaxLength(255);
            builder.Property(R=>R.Date);

            builder.HasOne(R=>R.Customer).WithMany().HasForeignKey(R=>R.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            ;
            builder.HasOne(R=>R.Item).WithMany().HasForeignKey(R => R.ItemID)
                .OnDelete(DeleteBehavior.Restrict);
            ;




        }
    }

}

