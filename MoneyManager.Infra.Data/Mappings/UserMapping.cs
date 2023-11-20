using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Infra.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(80);
        
        builder.Property(c => c.Password)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}