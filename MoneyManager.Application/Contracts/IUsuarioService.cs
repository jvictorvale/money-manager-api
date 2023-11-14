using MoneyManager.Application.DTOs.V1.Usuario;

namespace MoneyManager.Application.Contracts;

public interface IUsuarioService
{
    Task<UsuarioDto?> Cadastrar(AdicionarUsuarioDto usuarioDto);
    Task<UsuarioDto?> Atualizar(int id, AtualizarUsuarioDto usuarioDto);
    Task Remover(int id);
    Task<UsuarioDto?> ObterPorId(int id);
    Task<List<UsuarioDto>?> ObterTodos();
}