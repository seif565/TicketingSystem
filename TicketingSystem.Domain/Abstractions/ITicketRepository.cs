using TicketingSystem.Domain.Entities;
namespace TicketingSystem.Domain.Abstractions;

public interface ITicketRepository
{
    Task<Ticket?> GetTicketAsync(int id);
    Task<List<Ticket>> GetTicketsAsync(int pageNumber = 0, int pageSize = 50);
    Task<List<Ticket>> GetUnprocesssedTicketsAsync();
    Task InsertTicket(Ticket ticket);
    void Update(List<Ticket> tickets);
    void Update(Ticket ticket);
}
