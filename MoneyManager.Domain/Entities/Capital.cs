using FluentValidation.Results;
using MoneyManager.Domain.Validators;

namespace MoneyManager.Domain.Entities;

public class Capital : Entity
{
    public int UsuarioId { get; set; }
    public decimal RendaFixa { get; set; }
    public decimal RendaExtra { get; set; } // não-obrigatório 
    public decimal ReceitaTotal { get; set; }
    public decimal DespesaFixa { get; set; }
    public decimal DespesaExtra { get; set; } // não-obrigatório 
    public decimal Investimento { get; set; } // não-obrigatório
    public decimal DespesaTotal { get; set; }
    public decimal SaldoDisponivel { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public void CalcularReceitaTotal()
    {
        ReceitaTotal = RendaFixa + RendaExtra;
    }
    
    public void CalcularDespesaTotal()
    {
        DespesaTotal = DespesaFixa + DespesaExtra + Investimento;
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