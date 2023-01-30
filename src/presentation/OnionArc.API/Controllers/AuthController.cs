using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArc.Application.Features.CQRS.Queries.Users;
using OnionArc.Application.Tools;

namespace OnionArc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("action")]
    public async Task<IActionResult> Login(CheckUserQueryRequest request)
    {
        var dto = await _mediator.Send(request);
        if (dto.IsExist)
            return Created("", JwtTokenGenerator.GenerateToken(dto));
        else
            return BadRequest("Kullanıcı adı veya şifre hatalıdır.");
    }
}
