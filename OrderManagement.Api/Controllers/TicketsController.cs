using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordermanagement.Infrastructure.Services.Security;
using OrderManagement.Application.Tickets.Command;
using OrderManagement.Application.Tickets.Query;
using OrderManagement.Domain.Dtos;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Api.Controllers;

[ApiController]
[Route("Tickets")]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = Roles.Employee)]
    public async Task<IActionResult> CreateTicket([FromBody]CreateTicketCommand createTicketCommand)
    {
        var id = await _mediator.Send(createTicketCommand);
        return Ok(id);
    }

    [HttpGet("my")]
    [Authorize(Roles = Roles.Employee)]
    public async Task<IActionResult> GetMyTickets()
    {
        var result = await _mediator.Send(new GetMyTicketsQuery());
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> GetAllTickets()
    {
        var result = await _mediator.Send(new GetAllTicketsQuery());
        return Ok(result);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTicketRequest updateTicketRequest)
    {
        var result = await _mediator.Send(new UpdateTicketCommand(id, updateTicketRequest.Status));

        return Ok(result);
    }

    [HttpGet("stats")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> GetAllTicketsCount([FromQuery]Status status)
    {
        var result = await _mediator.Send(new GetTicketCountQuery(status));
        return Ok(result);
    }

    [HttpDelete]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteTicket([FromBody]DeleteTicketCommand deleteTicketCommand)
    {
        await _mediator.Send(deleteTicketCommand);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetTicket(Guid id)
    {
        var result = await _mediator.Send(new GetTicketByIdQuery(id));
        return Ok(result);
    }

    [HttpGet("ExceptionResultTest")]
    public IActionResult ExceptionResultTest()
    {
        throw new NotImplementedException();
    }
}
