using AutoMapper;
using MoneyManager.Application.DTOs.V1.Usuario;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Application.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<Usuario, AdicionarUsuarioDto>().ReverseMap();
        CreateMap<Usuario, AtualizarUsuarioDto>().ReverseMap();
    }
}