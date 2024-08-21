using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Application.DTOs.Ticket;
using TicketingSystem.Application.Tickets.Queries;

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
            List<TicketDto> s = await _mediator.Send(query);
            return Ok(s);
        }
    }
}
