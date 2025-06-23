using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd();
            
        builder.Property(o => o.InvoiceId)
            .HasColumnName("InvoiceId")
            .HasColumnType("int")
            .IsRequired();
            
        builder.Property(o => o.Status)
            .HasColumnName("Status")
            .HasConversion<int>()
            .IsRequired();
            
        builder.Property(o => o.CustomerId)
            .HasColumnName("CustomerId")
            .HasColumnType("int")
            .IsRequired();
            
        builder.HasIndex(o => o.CustomerId)
            .HasDatabaseName("IX_Order_CustomerId");
    }
}