using MediatR;

namespace TicketingSystem.Application.Tickets.Commands.HandleTicket;

public record HandleTicketCommand(int Id) : IRequest;
