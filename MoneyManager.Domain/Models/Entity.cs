using FluentValidation.Results;
using MoneyManager.Domain.Contratcts.Interfaces;

namespace MoneyManager.Domain.Models;

public class Entity : IEntity, ITracking
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual bool Validate(out ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        return validationResult.IsValid;
    }
}