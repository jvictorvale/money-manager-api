using MoneyManager.Domain.Contratcts.Interfaces;

namespace MoneyManager.Domain.Entities;

public class User : Entity, ITracking
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public Revenue Revenue { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}