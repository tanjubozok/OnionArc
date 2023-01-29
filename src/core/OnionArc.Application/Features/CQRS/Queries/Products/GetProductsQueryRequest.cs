using MediatR;
using OnionArc.Application.Dtos.ProductDtos;

namespace OnionArc.Application.Features.CQRS.Queries.Products;

public class GetProductsQueryRequest : IRequest<List<ProductListDto?>>
{
}
