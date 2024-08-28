using System.Linq.Expressions;
using UniqueIdentifiersBenchmark.Data.Entity;

namespace UniqueIdentifiersBenchmark.Data.Persistence.Contracts
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
