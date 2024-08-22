namespace TicketingSystem.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
    void SaveChanges();
}
