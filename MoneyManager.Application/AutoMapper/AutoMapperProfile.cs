using AutoMapper;
using MoneyManager.Application.DTOs.User;
using MoneyManager.Domain.Models;

namespace MoneyManager.Application.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region User
        
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<LoginUserDto, User>().ReverseMap();
        CreateMap<RegisterUserDto, User>().ReverseMap();
        CreateMap<UserDto, RegisterUserDto>().ReverseMap();
        
        #endregion
    }
}