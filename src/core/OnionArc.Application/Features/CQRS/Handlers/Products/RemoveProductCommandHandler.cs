using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Features.CQRS.Commands.Products;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Products;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequst>
{
    private readonly IRepository<Product> _repository;

    public RemoveProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveProductCommandRequst request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetByIdAsync(request.Id);
        if (data is not null)
        {
            await _repository.DeleteAsync(data);
        }
        return Unit.Value;
    }
}
