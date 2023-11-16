using FluentValidation;
using FluentValidation.Results;

namespace MoneyManager.Application.DTOs.User;

public class RegisterUserDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
    
    public bool Validate(out ValidationResult validationResult)
    {
        var validator = new InlineValidator<RegisterUserDto>();
        
        validator
            .RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O nome não pode ser vazio.")
            .Length(3, 150)
            .WithMessage("O nome deve conter entre {MinLength} e {MaxLength} caracteres.");

        validator
            .RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O email não pode ser vazio.")
            .EmailAddress()
            .WithMessage("O email fornecido não é válido.")
            .Length(3, 100)
            .WithMessage("O email deve conter entre {MinLength} e {MaxLength} caracteres.");

        validator
            .RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("A senha não pode ser vazia.")
            .Length(3, 250)
            .WithMessage("A senha deve conter entre {MinLength} e {MaxLength} caracteres.");

        validator
            .RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("O campo 'confirmar senha' não pode ser vazio.")
            .Equal(x => x.Password)
            .WithMessage("As senhas não coincidem.");

        validationResult = validator.Validate(this);
        
        return validationResult.IsValid;
    }
}