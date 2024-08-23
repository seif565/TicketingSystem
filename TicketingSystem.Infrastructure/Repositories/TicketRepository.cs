using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Abstractions;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Repositories;

public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
{    
    private readonly TicketDbContext _ticketDbContext;

    public TicketRepository(TicketDbContext ticketDbContext) : base(ticketDbContext)
    {
        _ticketDbContext = ticketDbContext;
    }

    public async Task<Ticket?> GetTicketAsync(int id)
        => await _ticketDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);        

    public async Task<List<Ticket>> GetTicketsAsync(int pageNumber = 0, int pageSize = 50)
    {
        return await _ticketDbContext.Tickets
            .OrderByDescending(x => x.CreatedAt)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Ticket>> GetUnprocesssedTicketsAsync()
    {
        return await _ticketDbContext.Tickets
            .Where(
                x => !x.Handled 
                && x.TicketColor != Domain.Enums.TicketColor.Red
            )            
            .ToListAsync();
    }

    public async Task InsertTicket(Ticket ticket)
    {
        await _ticketDbContext.Tickets.AddAsync(ticket);                        
    }

    public void Update(List<Ticket> tickets)
    {
        _ticketDbContext.Tickets.UpdateRange(tickets);
    }

    public void Update(Ticket ticket)
    {
        _ticketDbContext.Tickets.Update(ticket);
    }
}
