using AutoMapper;
using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Dtos.ProductDtos;
using OnionArc.Application.Features.CQRS.Queries.Products;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Products;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, List<ProductListDto?>>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductListDto?>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();
        return _mapper.Map<List<ProductListDto?>>(products);
    }
}