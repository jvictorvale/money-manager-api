using AutoMapper;
using Microsoft.AspNetCore.Http;
using MoneyManager.Application.Contracts;
using MoneyManager.Application.DTOs.Capital;
using MoneyManager.Application.Extensions;
using MoneyManager.Application.Notifications;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Application.Services;

public class CapitalService : BaseService, ICapitalService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICapitalRepository _capitalRepository;

    public CapitalService(
        IMapper mapper, 
        INotificator notificator, 
        IHttpContextAccessor httpContextAccessor, 
        ICapitalRepository capitalRepository) 
        : base(mapper, notificator)
    {
        _httpContextAccessor = httpContextAccessor;
        _capitalRepository = capitalRepository;
    }
    
    public async Task<CapitalDto?> Adicionar(AdicionarCapitalDto dto)
    {
        var capital = Mapper.Map<Capital>(dto);
        capital.UsuarioId = _httpContextAccessor.GetUserId() ?? 0;
        
        if (!Validar(capital))
        {
            return null;
        }
        
        capital.CalcularReceitaTotal();
        capital.CalcularDespesaTotal();
        capital.CalcularSaldoDisponivel();
        
        _capitalRepository.Adicionar(capital);
        
        if (await _capitalRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<CapitalDto>(capital);
        }
    
        Notificator.Handle("Não foi possível adicionar o capital.");
        return null;
    }

    public async Task<CapitalDto?> Atualizar(int id, AtualizarCapitalDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os IDs não conferem.");
            return null;
        }

        var obterCapital = await _capitalRepository.ObterPorId(id, _httpContextAccessor.GetUserId());
        
        if (obterCapital == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        Mapper.Map(dto, obterCapital);
        
        if (!Validar(obterCapital))
        {
            return null;
        }
        
        obterCapital.CalcularReceitaTotal();
        obterCapital.CalcularDespesaTotal();
        obterCapital.CalcularSaldoDisponivel();
        
        _capitalRepository.Atualizar(obterCapital);

        if (await _capitalRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<CapitalDto>(obterCapital);
        }

        Notificator.Handle("Não foi possível atualizar o capital.");
        return null;
    }
    
    public async Task<CapitalDto?> ObterPorId(int id)
    {
        var obterCapital = await _capitalRepository.ObterPorId(id, _httpContextAccessor.GetUserId());
        
        if (obterCapital != null)
        {
            return Mapper.Map<CapitalDto>(obterCapital);
        }

        Notificator.HandleNotFoundResource();
        return null;
    }
    
    private bool Validar(Capital capital)
    {
        if (!capital.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }
        
        return !Notificator.HasNotification;
    }
}