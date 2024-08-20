namespace TicketingSystem.Domain.Abstractions;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
    void SaveChanges();
}
