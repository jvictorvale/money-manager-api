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
            .IsRequired();

        builder
            .Property(x => x.RendaExtra)
            .IsRequired(false);

        builder
            .Property(x => x.ReceitaTotal)
            .IsRequired();
        
        builder
            .Property(x => x.DespesaFixa)
            .IsRequired();
        
        builder
            .Property(x => x.DespesaExtra)
            .IsRequired(false);
        
        builder
            .Property(x => x.Investimento)
            .IsRequired(false);
        
        builder
            .Property(x => x.DespesaTotal)
            .IsRequired();
        
        builder
            .Property(x => x.SaldoDisponivel)
            .IsRequired();
    }
}