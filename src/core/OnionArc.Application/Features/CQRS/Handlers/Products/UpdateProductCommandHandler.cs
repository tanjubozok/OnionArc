using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Features.CQRS.Commands.Products;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Products;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
{
    private readonly IRepository<Product> _repository;

    public UpdateProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetByIdAsync(request.Id);
        if (data is not null)
        {
            data.Name = request.Name;
            data.Stock = request.Stock;
            data.Price = request.Price;
            data.CategoryId = request.CategoryId;

            await _repository.SaveChangesAsync();
        }
        return Unit.Value;
    }
}
