using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Domain.Entities;
using MoneyManager.Infra.Data.Context;

namespace MoneyManager.Infra.Data.Repositories;

public  class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext context) : base(context)
    { }

    public void Cadastrar(Usuario usuario)
    {
        Context.Add(usuario);
    }

    public void Atualizar(Usuario usuario)
    {
        Context.Update(usuario);
    }

    public void Remover(Usuario usuario)
    {
        Context.Remove(usuario);
    }

    public async Task<Usuario?> ObterPorId(int id)
    {
        return await Context.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Usuario?> ObterPorEmail(string email)
    {
        return await Context.Usuarios.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<List<Usuario>> ObterTodos()
    {
        return await Context.Usuarios.AsNoTrackingWithIdentityResolution().ToListAsync();
    }
}