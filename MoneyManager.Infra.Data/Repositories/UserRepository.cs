using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Domain.Entities;
using MoneyManager.Infra.Data.Context;

namespace MoneyManager.Infra.Data.Repositories;

public  class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {}
    
    public void Register(User user)
    {
        Context.Users.Add(user);
    }
    
    public async Task<User?> GetByEmail(string email)
    {
        return await Context.Users.FirstOrDefaultAsync(c => c.Email == email);
    }
}