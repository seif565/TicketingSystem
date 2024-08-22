using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketingSystem.Domain.Abstractions;

namespace TicketingSystem.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly TicketDbContext _ticketDbContext;

    public BaseRepository(TicketDbContext ticketDbContext)
    {
        _ticketDbContext = ticketDbContext;
    }

    public void Add(TEntity entity) => _ticketDbContext.Set<TEntity>().Add(entity);

    public async Task AddAsync(TEntity entity) => await _ticketDbContext.Set<TEntity>().AddAsync(entity);

    public void Delete(TEntity entity) => _ticketDbContext.Set<TEntity>().Remove(entity);

    public TEntity First() => _ticketDbContext.Set<TEntity>().First() ?? throw new Exception();

    public async Task<TEntity> FirstOrDefaultAsync() => await _ticketDbContext.Set<TEntity>().FirstOrDefaultAsync();

    public IQueryable<TEntity> GetAll() => _ticketDbContext.Set<TEntity>().AsQueryable();

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression) => _ticketDbContext.Set<TEntity>().Where(expression).AsQueryable();

    public void Update(TEntity entity) => _ticketDbContext.Set<TEntity>().Update(entity);
}
