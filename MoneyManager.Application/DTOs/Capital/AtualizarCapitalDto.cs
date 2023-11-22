namespace MoneyManager.Application.DTOs.Capital;

public class AtualizarCapitalDto
{
    public int Id { get; set; }
    public decimal RendaFixa { get; set; }
    public decimal RendaExtra { get; set; } // não-obrigatório
    public decimal DespesaFixa { get; set; }
    public decimal DespesaExtra { get; set; } // não-obrigatório 
    public decimal Investimento { get; set; } // não-obrigatório 
}