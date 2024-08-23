using MediatR;
using TicketingSystem.Application.DTOs.Ticket;
using TicketingSystem.Domain.Abstractions;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.ValueObjects;

namespace TicketingSystem.Application.Tickets.Commands.CreateTicket;

internal sealed class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, TicketDto>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TicketDto> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        Governorate gov = Governorate.Create(request.Governorate);
        City city = City.Create(request.City);
        District district = District.Create(request.District);
        Ticket ticket = Ticket.Create(request.PhoneNumber, gov, city, district);
        await _ticketRepository.AddAsync(ticket);
        await _unitOfWork.SaveChangesAsync();
        return new TicketDto(ticket.Id, ticket.CreatedAt, ticket.PhoneNumber, ticket.Governorate.Name, ticket.City.Name, ticket.District.Name);
    }
}
