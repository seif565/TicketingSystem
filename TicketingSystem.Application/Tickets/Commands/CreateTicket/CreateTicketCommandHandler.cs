﻿using MediatR;
using TicketingSystem.Domain.Abstractions;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Application.Tickets.Commands.CreateTicket;

internal sealed class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        Ticket ticket = Ticket.Create(request.PhoneNumber, request.Governorate, request.City, request.District);
        await _ticketRepository.AddAsync(ticket);
        await _unitOfWork.SaveChangesAsync();        
    }
}
