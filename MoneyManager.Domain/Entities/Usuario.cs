using FluentValidation.Results;
using MoneyManager.Domain.Contratcts.Interfaces;
using MoneyManager.Domain.Validators;

namespace MoneyManager.Domain.Entities;

public class Usuario : Entity, IAggregateRoot
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new UsuarioValidator().Validate(this);
        return validationResult.IsValid;
    }
}