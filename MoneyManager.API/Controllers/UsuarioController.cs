using Microsoft.AspNetCore.Mvc;
using MoneyManager.API.Responses;
using MoneyManager.Application.Contracts;
using MoneyManager.Application.DTOs.Usuario;
using MoneyManager.Application.Notifications;
using Swashbuckle.AspNetCore.Annotations;

namespace MoneyManager.API.Controllers;

[Route("usuario")]
public class UsuarioController : MainController
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(INotificator notificator, IUsuarioService usuarioService) : base(notificator)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost("registrar")]
    [SwaggerOperation(Summary = "Registrar")]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Registrar([FromBody] AdicionarUsuarioDto dto)
    {
        var adicionarUsuario = await _usuarioService.Registrar(dto);
        return OkResponse(adicionarUsuario);
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = "Login")]
    [ProducesResponseType(typeof(TokenUsuarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return OkResponse(token);
    }
}