using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Features.CQRS.Commands;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var updatedEntity = await _repository.GetByIdAsync(request.Id);
        if (updatedEntity is not null)
        {
            updatedEntity.Definition = request.Definition;
            await _repository.UpdateAsync(updatedEntity);
        }
        return Unit.Value;
    }
}
