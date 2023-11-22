namespace MoneyManager.Application.DTOs.Capital;

public class CapitalDto
{
    public int Id { get; set; }
    public decimal ReceitaTotal { get; set; }
    public decimal DespesaTotal { get; set; }
    public decimal SaldoDisponivel { get; set; }
}