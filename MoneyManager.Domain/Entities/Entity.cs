using FluentValidation.Results;
using MoneyManager.Domain.Contratcts.Interfaces;

namespace MoneyManager.Domain.Entities;

public class Entity : IEntity
{
    public int Id { get; set; }

    public virtual bool Validate(out ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        return validationResult.IsValid;
    }
}