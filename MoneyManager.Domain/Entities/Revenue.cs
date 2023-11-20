namespace MoneyManager.Domain.Entities;

public class Revenue : Entity
{
    public string Title { get; set; } = null!;
    public string? Description;
    public int UserId { get; set; }

    public decimal BalanceAvailable => 0;
    public decimal BaseIncome => 0;

    public decimal ExtraIncome => 0;

    public decimal Savings => 0;

    public DateTime DepositedAt { get; set; }
    
    public User User { get; set; } = null!;
}