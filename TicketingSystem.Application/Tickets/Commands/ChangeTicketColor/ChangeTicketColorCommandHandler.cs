using MediatR;
using TicketingSystem.Domain.Abstractions;

namespace TicketingSystem.Application.Tickets.Commands.ChangeTicketColor;

public class ChangeTicketColorCommandHandler : IRequestHandler<ChangeTicketColorCommand>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeTicketColorCommandHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ChangeTicketColorCommand request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Ticket> tickets = await _ticketRepository.GetUnprocesssedTicketsAsync();
        tickets.ForEach(t => t.ChangeTicketColor());
        _ticketRepository.UpdateRange(tickets);
        await _unitOfWork.SaveChangesAsync();
    }
}
