using MediatR;
using OnionArc.Application.Dtos.CategoryDtos;

namespace OnionArc.Application.Features.CQRS.Commands.Categories;

public class CreateCategoryCommandRequest : IRequest<CategoryCreateDto?>
{
    public string? Definition { get; set; }
}
