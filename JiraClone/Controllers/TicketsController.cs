using Application.Features.Commands.TicketCommands.CreateTicket;
using Application.Features.Queries.TicketQueries.GetAllWithUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JiraClone.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithUser()
    {
        GetAllWithUserRequest req = new();
        List<GetAllWithUserResponse> res = await _mediator.Send(req);
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTicketRequest req)
    {
        var data = await _mediator.Send(req);
        return Ok(data);
    }
}