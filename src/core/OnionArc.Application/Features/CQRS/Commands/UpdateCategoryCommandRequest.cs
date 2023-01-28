using MediatR;

namespace OnionArc.Application.Features.CQRS.Commands;

public class UpdateCategoryCommandRequest : IRequest
{
    public int Id { get; set; }
    public string? Definition { get; set; }
}
