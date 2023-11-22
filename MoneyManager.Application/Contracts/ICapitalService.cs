using MoneyManager.Application.DTOs.Capital;

namespace MoneyManager.Application.Contracts;

public interface ICapitalService
{
    Task<CapitalDto?> Adicionar(AdicionarCapitalDto dto);
    Task<CapitalDto?> Atualizar(int id, AtualizarCapitalDto dto);
    Task<CapitalDto?> ObterPorId(int id);
}