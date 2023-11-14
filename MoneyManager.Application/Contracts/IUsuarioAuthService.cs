using MoneyManager.Application.DTOs.V1.Auth;

namespace MoneyManager.Application.Contracts;

public interface IUsuarioAuthService
{
    Task<TokenDto?> Login(LoginDto usuarioLoginDto);
}