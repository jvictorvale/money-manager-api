using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoneyManager.Application.Contracts;
using MoneyManager.Application.DTOs.Usuario;
using MoneyManager.Application.Notifications;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Application.Services;

public class UsuarioService : BaseService, IUsuarioService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher<Usuario> _passwordHasher;

    public UsuarioService(
        IMapper mapper,
        INotificator notificator,
        IConfiguration configuration,
        IUsuarioRepository usuarioRepository,
        IPasswordHasher<Usuario> passwordHasher
    ) : base(mapper, notificator)
    {
        _configuration = configuration;
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UsuarioDto?> Adicionar(AdicionarUsuarioDto dto)
    {
        if (!dto.Validate(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
            return null;
        }

        var obterUsuario = await _usuarioRepository.ObterPorEmail(dto.Email);
        if (obterUsuario != null)
        {
            Notificator.Handle("Já existe um usuário registrado com o email informado.");
            return null;
        }
        
        var usuario = Mapper.Map<Usuario>(dto);
        usuario.Senha = _passwordHasher.HashPassword(usuario, dto.Senha);

        _usuarioRepository.Adicionar(usuario);

        if (await _usuarioRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<UsuarioDto>(usuario);
        }

        Notificator.Handle("Não foi possível registrar o usuário.");
        return null;
    }
    
    public async Task<TokenUsuarioDto?> Login(LoginUsuarioDto dto)
    {
        if (!dto.Validate(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
            return null;
        }

        var usuario = await _usuarioRepository.ObterPorEmail(dto.Email);

        if (usuario != null && _passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, 
                dto.Senha) == PasswordVerificationResult.Success)
        {
            return GerarToken(usuario);
        }

        Notificator.Handle("Email ou senha estão incorretos.");
        return null;
    }
    
    private TokenUsuarioDto GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"] ?? string.Empty);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Role, "Usuario"),
                new(ClaimTypes.Name, usuario.Nome),
                new(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            }),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Expires = 
                DateTime.UtcNow.AddHours(int.Parse(_configuration["AppSettings:ExpirationHours"] ?? string.Empty)),
            Issuer = _configuration["AppSettings:Issuer"],
            Audience = _configuration["AppSettings:ValidOn"]
        });

        var encodedToken = tokenHandler.WriteToken(token);

        return new TokenUsuarioDto
        {
            Token = encodedToken
        };
    }
}