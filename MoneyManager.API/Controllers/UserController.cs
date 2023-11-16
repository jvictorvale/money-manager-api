using Microsoft.AspNetCore.Mvc;
using MoneyManager.API.Responses;
using MoneyManager.Application.Contracts;
using MoneyManager.Application.DTOs.User;
using MoneyManager.Application.Notifications;
using Swashbuckle.AspNetCore.Annotations;

namespace MoneyManager.API.Controllers;

[Route("user")]
public class UserController : MainController
{
    private readonly IUserService _userService;

    public UserController(INotificator notificator, IUserService userService) : base(notificator)
    {
        _userService = userService;
    }
    
    [HttpPost("register")]
    [SwaggerOperation(Summary = "Register user")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        var registerUser = await _userService.Register(dto);
        return OkResponse(registerUser);
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = "Login")]
    [ProducesResponseType(typeof(TokenUserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        var token = await _userService.Login(dto);
        return OkResponse(token);
    }
}