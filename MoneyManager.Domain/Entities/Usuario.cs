using MoneyManager.Domain.Contratcts.Interfaces;

namespace MoneyManager.Domain.Entities;

public class Usuario : Entity, ITracking
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
    public Capital Capital { get; set; } = null!;
}