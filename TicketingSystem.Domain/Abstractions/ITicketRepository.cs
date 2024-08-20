using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Abstractions;

public interface ITicketRepository
{
    Task<List<Ticket>> GetTicketsAsync(int pageNumber = 0, int pageSize = 50);
    Task InsertTicket(Ticket ticket);
}
