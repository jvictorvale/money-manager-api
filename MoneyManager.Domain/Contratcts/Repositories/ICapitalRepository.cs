using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Contratcts.Repositories;

public interface ICapitalRepository
{
    Task<Capital?> ObterPorId(int id, int? usuarioId);
}