using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.API.Responses;
using MoneyManager.Application.Contracts;
using MoneyManager.Application.DTOs.Capital;
using MoneyManager.Application.Notifications;
using Swashbuckle.AspNetCore.Annotations;

namespace MoneyManager.API.Controllers;

[Authorize]
[Route("capital")]
public class CapitalController : MainController
{
    private readonly ICapitalService _capitalService;
    
    public CapitalController(INotificator notificator, ICapitalService capitalService) : base(notificator)
    {
        _capitalService = capitalService;
    }
    
    [HttpPost("adicionar")]
    [SwaggerOperation(Summary = "Adicionar capital")]
    [ProducesResponseType(typeof(CapitalDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarCapitalDto dto)
    {
        var adicionarCapital = await _capitalService.Adicionar(dto);
        return OkResponse(adicionarCapital);
    }
    
    [HttpPut("atualizar/{id}")]
    [SwaggerOperation("Atualizar capital")]
    [ProducesResponseType(typeof(CapitalDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarCapitalDto dto)
    {
        var atualizarCapital = await _capitalService.Atualizar(id, dto);
        return OkResponse(atualizarCapital);
    }
    
    [HttpGet("obter-por-id/{id}")]
    [SwaggerOperation(Summary = "Obter por id um capital")]
    [ProducesResponseType(typeof(CapitalDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var obterCapital = await _capitalService.ObterPorId(id);
        return OkResponse(obterCapital);
    }
}