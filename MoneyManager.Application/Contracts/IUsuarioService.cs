using MoneyManager.Application.DTOs.Usuario;

namespace MoneyManager.Application.Contracts;

public interface IUsuarioService
{
    Task<UsuarioDto?> Registrar(AdicionarUsuarioDto dto);
    Task<TokenUsuarioDto?> Login(LoginUsuarioDto dto);
}