using MediatR;

namespace TicketingSystem.Application.Tickets.Commands
{
    public class CreateTicketCommand : IRequest
    {
        public string PhoneNumber { get; set; }
    }
}
