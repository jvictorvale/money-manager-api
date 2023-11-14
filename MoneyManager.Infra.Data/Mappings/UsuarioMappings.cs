using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Infra.Data.Mappings;

public class UsuarioMappings : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(80);
        
        builder.Property(c => c.Senha)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}