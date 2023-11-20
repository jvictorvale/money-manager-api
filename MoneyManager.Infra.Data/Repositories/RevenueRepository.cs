using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Domain.Entities;
using MoneyManager.Infra.Data.Context;

namespace MoneyManager.Infra.Data.Repositories;

public class RevenueRepository : Repository<Revenue>, IRevenueRepository
{
    public RevenueRepository(ApplicationDbContext context) : base(context)
    { }

    public async Task<Revenue?> GetById(int? id, int? userId)
    {
        return await Context.Revenues
            .FirstOrDefaultAsync(x => id != null && x.Id == id && x.UserId == userId);
    }
}