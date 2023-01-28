using AutoMapper;
using OnionArc.Application.Dtos.CategoryDtos;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryListDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
    }
}
