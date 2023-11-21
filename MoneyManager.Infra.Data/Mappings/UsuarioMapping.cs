using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Infra.Data.Mappings;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder
            .Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(x => x.Senha)
            .IsRequired()
            .HasMaxLength(255);

        builder
            .HasOne(x => x.Capital)
            .WithOne(x => x.Usuario);
    }
}