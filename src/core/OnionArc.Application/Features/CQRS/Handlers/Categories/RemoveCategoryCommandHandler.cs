using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Features.CQRS.Commands.Categories;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Categories;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest>
{
    private readonly IRepository<Category> _repository;

    public RemoveCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var removedEntity = await _repository.GetByIdAsync(request.Id);
        if (removedEntity is not null)
        {
            await _repository.DeleteAsync(removedEntity);
        }
        return Unit.Value;
    }
}
