using AutoMapper;
using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Dtos.CategoryDtos;
using OnionArc.Application.Features.CQRS.Commands.Categories;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Categories;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CategoryCreateDto?>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
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
