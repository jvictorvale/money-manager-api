using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Contratcts.Repositories;

public interface IRevenueRepository : IRepository<Revenue>
{
     Task<Revenue?> GetById(int? id, int? userId);
}