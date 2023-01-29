using MediatR;
using OnionArc.Application.Dtos.CategoryDtos;

namespace OnionArc.Application.Features.CQRS.Queries.Categories;

public class GetCategoryQueryRequest : IRequest<CategoryListDto?>
{
    public int Id { get; set; }

    public GetCategoryQueryRequest(int id)
    {
        Id = id;
    }
}
