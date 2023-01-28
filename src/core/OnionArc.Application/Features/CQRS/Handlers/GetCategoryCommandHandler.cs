using AutoMapper;
using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Dtos.CategoryDtos;
using OnionArc.Application.Features.CQRS.Commands;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers;

public class GetCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CategoryCreateDto?>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryCreateDto?> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Category category = new()
        {
            Definition = request.Definition
        };
        var data = await _repository.CreateAsync(category);
        return _mapper.Map<CategoryCreateDto>(data);
    }
}
