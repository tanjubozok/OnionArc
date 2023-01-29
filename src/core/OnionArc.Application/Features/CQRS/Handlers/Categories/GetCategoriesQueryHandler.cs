using AutoMapper;
using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Dtos.CategoryDtos;
using OnionArc.Application.Features.CQRS.Queries.Categories;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Categories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync();
        return _mapper.Map<List<CategoryListDto>>(categories);
    }
}
