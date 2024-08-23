using MediatR;
using TicketingSystem.Domain.Abstractions;
using TicketingSystem.Domain.Exceptions;

namespace TicketingSystem.Application.Tickets.Commands.HandleTicket;

internal class HandleTicketCommandHandler : IRequestHandler<HandleTicketCommand>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HandleTicketCommandHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(HandleTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetTicketAsync(request.Id) ?? throw new NotFoundException(request.Id);
        ticket?.HandleTicket();
        _ticketRepository.Update(ticket);
        await _unitOfWork.SaveChangesAsync();
        
    }
}
