using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Abstractions;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDbContext _ticketDbContext;

        public TicketRepository(TicketDbContext ticketDbContext)
        {
            _ticketDbContext = ticketDbContext;
        }

        public async Task<List<Ticket>> GetTicketsAsync(int pageNumber = 0, int pageSize = 50)
        {
            return await _ticketDbContext.Tickets
                .OrderByDescending(x => x.CreatedAt)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task InsertTicket(Ticket ticket)
        {
            await _ticketDbContext.Tickets.AddAsync(ticket);
            await _ticketDbContext.SaveChangesAsync();
            throw new NotImplementedException();
        }
    }
}
