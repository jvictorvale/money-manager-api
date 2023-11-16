using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoneyManager.Application.Contracts;
using MoneyManager.Application.DTOs.User;
using MoneyManager.Application.Notifications;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Domain.Models;

namespace MoneyManager.Application.Services;

public class UserService : BaseService, IUserService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(
        IMapper mapper,
        INotificator notificator,
        IConfiguration configuration,
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher
    ) : base(mapper, notificator)
    {
        _configuration = configuration;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserDto?> Register(RegisterUserDto dto)
    {
        if (!dto.Validate(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
            return null;
        }

        var getUser = await _userRepository.GetByEmail(dto.Email);

        if (getUser != null)
        {
            Notificator.Handle("Já existe um usuário registrado com o email informado.");
            return null;
        }
        
        var user = Mapper.Map<User>(dto);

        user.Password = _passwordHasher.HashPassword(user, dto.Password);

        _userRepository.Register(user);

        if (await _userRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<UserDto>(user);
        }

        Notificator.Handle("Não foi possível registrar o usuário.");
        return null;
    }
    
    public async Task<TokenUserDto?> Login(LoginUserDto dto)
    {
        if (!dto.Validate(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
            return null;
        }

        var user = await _userRepository.GetByEmail(dto.Email);

        if (user != null && _passwordHasher.VerifyHashedPassword(user, user.Password, 
                dto.Password) == PasswordVerificationResult.Success)
        {
            return GenerateToken(user);
        }

        Notificator.Handle("Email ou senha estão incorretos.");
        return null;
    }
    
    private TokenUserDto GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"] ?? string.Empty);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Role, "User"),
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            }),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Expires = 
                DateTime.UtcNow.AddHours(int.Parse(_configuration["AppSettings:ExpirationHours"] ?? string.Empty)),
            Issuer = _configuration["AppSettings:Issuer"],
            Audience = _configuration["AppSettings:ValidOn"]
        });

        var encodedToken = tokenHandler.WriteToken(token);

        return new TokenUserDto
        {
            Token = encodedToken
        };
    }
}