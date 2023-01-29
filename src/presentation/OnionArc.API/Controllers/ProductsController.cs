using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArc.Application.Features.CQRS.Commands.Products;
using OnionArc.Application.Features.CQRS.Queries.Products;

namespace OnionArc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var data = await _mediator.Send(new GetProductsQueryRequest());
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByProduct(int id)
    {
        var data = await _mediator.Send(new GetProductQueryRequest(id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommandRequest request)
    {
        var data = await _mediator.Send(request);
        return Created("", data);
    }

    [HttpPut]
    public async Task<IActionResult> Updata(UpdateProductCommandRequest request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _mediator.Send(new RemoveProductCommandRequst(id));
        return NoContent();
    }
}
