using TicketingSystem.Domain.Entities;
namespace TicketingSystem.Domain.Abstractions;

public interface ITicketRepository : IBaseRepository<Ticket>
{
    Task<Ticket?> GetTicketAsync(int id);
    Task<List<Ticket>> GetTicketsAsync(int pageNumber = 0, int pageSize = 50);
    Task<List<Ticket>> GetUnprocesssedTicketsAsync();
}
