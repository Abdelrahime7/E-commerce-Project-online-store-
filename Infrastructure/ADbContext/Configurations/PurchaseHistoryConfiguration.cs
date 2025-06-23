using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configurations;

public class PurchaseHistoryConfiguration : IEntityTypeConfiguration<PurchaseHistory>
{
    public void Configure(EntityTypeBuilder<PurchaseHistory> builder)
    {
        builder.ToTable("PurchaseHistory");
        
        builder.HasKey(ph => ph.Id);
        
        builder.Property(ph => ph.Id)
            .ValueGeneratedOnAdd();
            
        builder.Property(ph => ph.OrderId)
            .HasColumnName("OrderId")
            .HasColumnType("int")
            .IsRequired();
            
        builder.Property(ph => ph.CustomerId)
            .HasColumnName("CustomerId")
            .HasColumnType("int")
            .IsRequired();
            
        builder.HasIndex(ph => ph.CustomerId)
            .HasDatabaseName("IX_PurchaseHistory_CustomerId");
    }
}