using FluentValidation;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Validators;

public class UsuarioValidator : AbstractValidator<Usuario>
{
    public UsuarioValidator()
    {
        RuleFor(u => u.Nome)
            .NotEmpty()
            .WithMessage("O nome deve ser informado.")
            .Length(3,80)
            .WithMessage("O nome deve ter no mínimo {MinLength} e no máximo {MaxLength} caracteres.");
        
        RuleFor(u => u.Senha)
            .NotEmpty()
            .WithMessage("A senha deve ser informada.")
            .Length(6, 20)
            .WithMessage("A senha deve ter no mínimo {MinLength} e no máximo {MaxLength} caracteres.");
        
        RuleFor(u => u.Email)
            .EmailAddress();
    }
}