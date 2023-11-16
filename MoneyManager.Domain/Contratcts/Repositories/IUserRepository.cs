using MoneyManager.Domain.Models;

namespace MoneyManager.Domain.Contratcts.Repositories;

public interface IUserRepository : IRepository<User>
{
    void Register(User user);
    Task<User?> GetByEmail(string email);
}