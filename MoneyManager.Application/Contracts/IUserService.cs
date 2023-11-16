using MoneyManager.Application.DTOs.User;

namespace MoneyManager.Application.Contracts;

public interface IUserService
{
    Task<UserDto?> Register(RegisterUserDto dto);
    Task<TokenUserDto?> Login(LoginUserDto dto);
}