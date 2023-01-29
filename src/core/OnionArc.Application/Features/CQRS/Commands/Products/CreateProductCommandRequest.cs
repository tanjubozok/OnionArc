using MediatR;
using OnionArc.Application.Dtos.ProductDtos;

namespace OnionArc.Application.Features.CQRS.Commands.Products;

public class CreateProductCommandRequest : IRequest<ProductCreateDto?>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}
