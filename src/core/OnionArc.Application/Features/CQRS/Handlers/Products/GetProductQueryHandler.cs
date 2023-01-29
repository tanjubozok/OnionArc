using AutoMapper;
using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Dtos.ProductDtos;
using OnionArc.Application.Features.CQRS.Queries.Products;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Products;

public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto?>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductListDto?> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
        return _mapper.Map<ProductListDto>(data);
    }
}
