using AutoMapper;
using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Dtos.CategoryDtos;
using OnionArc.Application.Features.CQRS.Queries.Categories;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Categories;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto?>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryListDto?> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
        return _mapper.Map<CategoryListDto>(data);
    }
}
