using UniqueIdentifiersBenchmark.Data.Entity;

namespace UniqueIdentifiersBenchmark.Data.Persistence.Contracts
{
    public interface IBookRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IBook<TKey>
    {
        Task<TEntity> GetWithAuthorByIdAsync(TKey id);
    }
}
