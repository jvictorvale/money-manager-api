using FluentValidation;
using FluentValidation.Results;

namespace MoneyManager.Application.DTOs.Usuario;

public class LoginUsuarioDto
{
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    
    public bool Validate(out ValidationResult validationResult)
    {
        var validator = new InlineValidator<LoginUsuarioDto>();
        
        validator
            .RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O email deve ser informado.")
            .EmailAddress()
            .WithMessage("O email fornecido não é válido.")
            .Length(3, 100)
            .WithMessage("O email deve conter entre {MinLength} e {MaxLength} caracteres.");

        validator
            .RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage("A senha deve ser informada.")
            .Length(3, 255)
            .WithMessage("A senha deve conter entre {MinLength} e {MaxLength} caracteres.");

        validationResult = validator.Validate(this);
        return validationResult.IsValid;
    }
}