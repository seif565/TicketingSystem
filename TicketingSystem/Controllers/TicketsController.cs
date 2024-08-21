using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Application.DTOs.Ticket;
using TicketingSystem.Application.Tickets.Commands.CreateTicket;
using TicketingSystem.Application.Tickets.Commands.HandleTicket;
using TicketingSystem.Application.Tickets.Queries.GetTickets;

namespace TicketingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketsAsync([FromQuery] GetTicketsQuery query)
        {
            List<TicketDto> tickets = await _mediator.Send(query);
            return Ok(tickets);
        }

        [HttpPut]
        public async Task<IActionResult> HandleTicket(HandleTicketCommand command) 
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(CreateTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
