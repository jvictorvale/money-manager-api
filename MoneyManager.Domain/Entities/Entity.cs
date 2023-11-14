using FluentValidation.Results;
using MoneyManager.Domain.Contratcts.Interfaces;

namespace MoneyManager.Domain.Entities;

public class Entity : IEntity, ITracking
{
    public int Id { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }

    public virtual bool Validar(out ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        return validationResult.IsValid;
    }
}