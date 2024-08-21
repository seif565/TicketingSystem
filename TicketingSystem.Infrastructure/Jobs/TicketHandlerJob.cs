using MediatR;
using TicketingSystem.Application.Jobs;
using TicketingSystem.Application.Tickets.Commands.ChangeTicketColor;
using TicketingSystem.Domain.Abstractions;

namespace TicketingSystem.Infrastructure.Jobs;

public class TicketHandlerJob : ITicketHandlerJob
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMediator _mediator;

    public TicketHandlerJob(ITicketRepository ticketRepository, IMediator mediator)
    {
        _ticketRepository = ticketRepository;
        _mediator = mediator;
    }

    public async Task UpdateTicketStatusesAsync(CancellationToken cancellationToken)
    {
        await _mediator.Send(new ChangeTicketColorCommand(), cancellationToken);            
    }
}
