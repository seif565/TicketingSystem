using MediatR;
using TicketingSystem.Application.DTOs.Ticket;

namespace TicketingSystem.Application.Tickets.Commands.CreateTicket;

public class CreateTicketCommand : IRequest<TicketDto>
{
    public string PhoneNumber { get; set; }
    public string Governorate { get; set; }
    public string City { get; set; }
    public string District { get; set; }
}
