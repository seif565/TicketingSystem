using MediatR;
using TicketingSystem.Application.DTOs.Ticket;
using TicketingSystem.Application.Tickets.Queries.GetTickets;
using TicketingSystem.Domain.Abstractions;

namespace TicketingSystem.Application.Tickets.Queries
{
    public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, List<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketsQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            ICollection<Domain.Entities.Ticket> ticketsDto = await _ticketRepository.GetTicketsAsync(request.PageCount, request.PageSize);
            return ticketsDto.Select(x => new TicketDto { CreatedAt = x.CreatedAt, Id = x.Id, PhoneNumber = x.PhoneNumber }).ToList();
        }
    }
}
