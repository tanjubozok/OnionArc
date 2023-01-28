using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArc.Application.Features.CQRS.Commands;
using OnionArc.Application.Features.CQRS.Queries;

namespace OnionArc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var categories = await _mediator.Send(new GetCategoriesQueryRequest());
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _mediator.Send(new GetCategoryQueryRequest(id));
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
    {
        var result = await _mediator.Send(request);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new RemoveCategoryCommandRequest(id));
        return NoContent();
    }
}
