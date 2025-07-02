using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");
            builder.HasKey(P => P.Id);

            builder.Property(P => P.FName).HasMaxLength(50);
            builder.Property(P => P.LName).HasMaxLength(50);
            builder.Property(P => P.Phone).HasMaxLength(50);
            builder.Property(P => P.Email).HasMaxLength(50);

        }
    }

}

