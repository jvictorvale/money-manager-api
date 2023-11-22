using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Infra.Data.Mappings;

public class CapitalMapping : IEntityTypeConfiguration<Capital>
{
    public void Configure(EntityTypeBuilder<Capital> builder)
    {
        builder
            .Property(x => x.UsuarioId)
            .IsRequired();

        builder
            .Property(x => x.RendaFixa)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder
            .Property(x => x.RendaExtra)
            .IsRequired(false)
            .HasColumnType("decimal(18,2)");

        builder
            .Property(x => x.ReceitaTotal)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        
        builder
            .Property(x => x.DespesaFixa)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        
        builder
            .Property(x => x.DespesaExtra)
            .IsRequired(false)
            .HasColumnType("decimal(18,2)");
        
        builder
            .Property(x => x.Investimento)
            .IsRequired(false)
            .HasColumnType("decimal(18,2)");
        
        builder
            .Property(x => x.DespesaTotal)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        
        builder
            .Property(x => x.SaldoDisponivel)
            .IsRequired()
            ;
    }
}