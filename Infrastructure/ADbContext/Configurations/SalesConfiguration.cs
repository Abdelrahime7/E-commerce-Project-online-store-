using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configurations;

public class SalesConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");
        
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();
            
        builder.Property(s => s.OrderId)
            .HasColumnName("OrderId")
            .HasColumnType("int")
            .IsRequired();
            
        builder.Property(s => s.TotalAmount)
            .HasColumnName("TotalAmount")
            .HasColumnType("decimal(12,2)")
            .IsRequired();
            
        builder.HasIndex(s => s.OrderId)
            .HasDatabaseName("IX_Sales_OrderId")
            .IsUnique();
    }
}