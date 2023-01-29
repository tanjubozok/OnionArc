using MediatR;

namespace OnionArc.Application.Features.CQRS.Commands.Products;

public class RemoveProductCommandRequst : IRequest
{
    public int Id { get; set; }

    public RemoveProductCommandRequst(int id)
    {
        Id = id;
    }
}
