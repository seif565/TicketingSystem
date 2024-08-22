using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Abstractions;

namespace TicketingSystem.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TicketDbContext _context;    

    public UnitOfWork(TicketDbContext context)
    {
        _context = context;
    }


    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context?.Dispose();
    }
}
