using AutoMapper;
using MoneyManager.Application.DTOs.Usuario;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Application.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region Usuario
        
        CreateMap<UsuarioDto, Usuario>().ReverseMap();
        CreateMap<LoginUsuarioDto, Usuario>().ReverseMap();
        CreateMap<AdicionarUsuarioDto, Usuario>().ReverseMap();
        CreateMap<UsuarioDto, AdicionarUsuarioDto>().ReverseMap();
        
        #endregion
    }
}