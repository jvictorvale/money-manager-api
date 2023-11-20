using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Infra.Data.Mappings;

public class RevenueMapping : IEntityTypeConfiguration<Revenue>
{
    public void Configure(EntityTypeBuilder<Revenue> builder)
    {
        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(40);
        
        builder.Property(c => c.BaseIncome)
            .IsRequired()
            .HasColumnType("decimal(18, 2)");
            
    }
}