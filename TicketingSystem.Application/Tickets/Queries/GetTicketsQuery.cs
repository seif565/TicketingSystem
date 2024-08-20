using MediatR;

namespace TicketingSystem.Application.Tickets.Queries
{
    public class GetTicketsQuery : IRequest<List<TicketDto>>
    {
        public int PageSize { get; set; } = 50;
        public int PageCount { get; set; } = 0;
    }
}
