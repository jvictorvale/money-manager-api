using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Domain.Entities;
using MoneyManager.Infra.Data.Context;

namespace MoneyManager.Infra.Data.Repositories;

public class CapitalRepository : Repository<Capital>, ICapitalRepository
{
    public CapitalRepository(ApplicationDbContext context) : base(context)
    { }

    public async Task<Capital?> ObterPorId(int id, int? usuarioId)
    {
        return await Context.Capitais.FirstOrDefaultAsync(x => x.Id == id && x.UsuarioId == usuarioId);
    }
}