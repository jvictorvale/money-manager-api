using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Contratcts.Repositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    void Cadastrar(Usuario usuario);
    void Atualizar(Usuario usuario);
    void Remover(Usuario usuario);
    Task<Usuario?> ObterPorId(int id);
    Task<Usuario?> ObterPorEmail(string email);
    Task<List<Usuario>> ObterTodos();
}