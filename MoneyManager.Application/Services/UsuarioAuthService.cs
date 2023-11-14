using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoneyManager.Application.Contracts;
using MoneyManager.Application.DTOs.V1.Auth;
using MoneyManager.Application.Notifications;
using MoneyManager.Core.Settings;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Domain.Entities;
using NetDevPack.Security.Jwt.Core.Interfaces;

namespace MoneyManager.Application.Services;

public class UsuarioAuthService : BaseService, IUsuarioAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher<Usuario> _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly JwtSettings _jwtSettings;
    
    public UsuarioAuthService(
        IMapper mapper, 
        INotificator notificator, 
        IUsuarioRepository usuarioRepository, 
        IPasswordHasher<Usuario> passwordHasher, 
        IOptions<JwtSettings> jwtSettings, 
        IJwtService jwtService) 
        : base(mapper, notificator)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<TokenDto?> Login(LoginDto usuarioLoginDto)
    {
        var usuario = await _usuarioRepository.ObterPorEmail(usuarioLoginDto.Email);
        if (usuario == null)
        {
            return null;
        }

        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, usuarioLoginDto.Senha);
        if (result == PasswordVerificationResult.Failed)
        {
            return null;
        }

        return new TokenDto
        {
            Token = await GerarToken(usuario)
        };
    }
    
    private async Task<string> GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));

        var key = await _jwtService.GetCurrentSigningCredentials();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _jwtSettings.Emissor,
            Subject = claimsIdentity,
            Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
            SigningCredentials = key
        });

        return tokenHandler.WriteToken(token);
    }
}