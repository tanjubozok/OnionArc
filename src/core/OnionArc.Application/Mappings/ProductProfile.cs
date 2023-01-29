using AutoMapper;
using OnionArc.Application.Dtos.ProductDtos;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        this.CreateMap<Product, ProductListDto>().ReverseMap();
        this.CreateMap<Product, ProductCreateDto>().ReverseMap();
    }
}
