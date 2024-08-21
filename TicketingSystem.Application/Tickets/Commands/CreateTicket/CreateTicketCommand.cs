using MediatR;

namespace TicketingSystem.Application.Tickets.Commands.CreateTicket;

public class CreateTicketCommand : IRequest
{
    public string PhoneNumber { get; set; }
    public string Governorate { get; set; }
    public string City { get; set; }
    public string District { get; set; }
}
