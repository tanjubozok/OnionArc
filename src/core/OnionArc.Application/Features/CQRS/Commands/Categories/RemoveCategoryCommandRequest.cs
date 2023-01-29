using MediatR;

namespace OnionArc.Application.Features.CQRS.Commands.Categories;

public class RemoveCategoryCommandRequest : IRequest
{
    public int Id { get; set; }

    public RemoveCategoryCommandRequest(int ıd)
    {
        Id = ıd;
    }
}
