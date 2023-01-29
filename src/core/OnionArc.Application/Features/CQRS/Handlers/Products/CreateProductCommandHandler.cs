using AutoMapper;
using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Dtos.ProductDtos;
using OnionArc.Application.Features.CQRS.Commands.Products;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ProductCreateDto?>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
    {
        this._repository = repository;
        this._mapper = mapper;
    }

    public async Task<ProductCreateDto?> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Product product = new()
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId,
            Stock = request.Stock
        };
        var data = await _repository.CreateAsync(product);
        return _mapper.Map<ProductCreateDto>(data);
    }
}
