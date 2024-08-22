using System.Linq.Expressions;

namespace TicketingSystem.Domain.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FirstOrDefaultAsync();
        TEntity First();
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
