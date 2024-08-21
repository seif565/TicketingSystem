using MediatR;
using TicketingSystem.Application.DTOs.Ticket;

namespace TicketingSystem.Application.Tickets.Queries.GetTickets
{
    public class GetTicketsQuery : IRequest<List<TicketDto>>
    {
        public int PageSize { get; set; } = 50;
        public int PageCount { get; set; } = 0;
    }
}
