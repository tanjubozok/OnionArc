using MediatR;
using OnionArc.Application.Dtos.CategoryDtos;

namespace OnionArc.Application.Features.CQRS.Queries;

public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
{
}
