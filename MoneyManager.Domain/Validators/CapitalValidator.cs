using FluentValidation;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Validators;

public class CapitalValidator : AbstractValidator<Capital>
{
    public CapitalValidator()
    {
        RuleFor(x => x.RendaFixa)
            .NotEmpty()
            .WithMessage("A renda fixa deve ser informada.")
            .GreaterThanOrEqualTo(0)
            .WithMessage("A renda fixa deve ser maior ou igual a zero.");
        
        RuleFor(x => x.RendaExtra)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A renda extra deve ser maior ou igual a zero.");
        
        RuleFor(x => x.DespesaFixa)
            .NotEmpty()
            .WithMessage("A despesa fixa deve ser informada.")
            .GreaterThanOrEqualTo(0)
            .WithMessage("A despesa fixa deve ser maior ou igual a zero.");
        
        RuleFor(x => x.DespesaExtra)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A despesa extra deve ser maior ou igual a zero.");
        
        RuleFor(x => x.Investimento)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O investimento deve ser maior ou igual a zero.");
    }
}