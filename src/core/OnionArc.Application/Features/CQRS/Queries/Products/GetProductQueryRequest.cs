using MediatR;
using OnionArc.Application.Dtos.ProductDtos;

namespace OnionArc.Application.Features.CQRS.Queries.Products;

public class GetProductQueryRequest : IRequest<ProductListDto?>
{
    public int Id { get; set; }

    public GetProductQueryRequest(int id)
    {
        Id = id;
    }
}
