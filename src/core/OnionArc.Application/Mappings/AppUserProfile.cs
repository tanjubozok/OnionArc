using AutoMapper;
using OnionArc.Application.Dtos.UserDtos;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Mappings;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        this.CreateMap<AppUser, CreatedUserDto>().ReverseMap();
    }
}
