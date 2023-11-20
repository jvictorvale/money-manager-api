using FluentValidation;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Validators;

public class RevenueValidator : AbstractValidator<Revenue>
{
    public RevenueValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("O titulo deve ser informado.")
            .Length(3, 20)
            .WithMessage("O titulo deve ter no mínimo {MinLength} e no máximo {MaxLength} caracteres.");

        RuleFor(x => x.Description)
            .Length(3, 40)
            .WithMessage("O descrição deve ter no mínimo {MinLength} e no máximo {MaxLength} caracteres.");
        
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotEqual(0)
            .WithMessage("O id do usuário deve ser informado.");

        RuleFor(x => x.BaseIncome)
            .NotEmpty()
            .WithMessage("o salário base deve ser informado.")
            .GreaterThanOrEqualTo(0)
            .WithMessage("O salário base deve ser maior ou igual a zero.");
        
        RuleFor(x => x.ExtraIncome)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A renda extra deve ser maior ou igual a zero.");
        
        RuleFor(x => x.Savings)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O valor adicionado na poupança deve ser maior ou igual a zero.");
    }
}