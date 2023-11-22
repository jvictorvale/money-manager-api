using System.ComponentModel.DataAnnotations;
using MoneyManager.Domain.Validators;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MoneyManager.Domain.Entities;

public class Capital : Entity
{
    public int UsuarioId { get; set; }
    public decimal RendaFixa { get; set; }
    public decimal? RendaExtra { get; set; }
    public decimal ReceitaTotal { get; set; }
    public decimal DespesaFixa { get; set; }
    public decimal? DespesaExtra { get; set; } 
    public decimal? Investimento { get; set; } 
    public decimal DespesaTotal { get; set; }
    public decimal SaldoDisponivel { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public void CalcularReceitaTotal()
    {
        ReceitaTotal = RendaFixa + (RendaExtra ?? 0);
    }
    
    public void CalcularDespesaTotal()
    {
        DespesaTotal = DespesaFixa + (DespesaExtra ?? 0) + (Investimento ?? 0);
    }

    public void CalcularSaldoDisponivel()
    { 
        SaldoDisponivel = ReceitaTotal - DespesaTotal;
    }
    
    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new CapitalValidator().Validate(this);
        return validationResult.IsValid;
    }
}