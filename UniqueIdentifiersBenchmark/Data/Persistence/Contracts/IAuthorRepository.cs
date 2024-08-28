using UniqueIdentifiersBenchmark.Data.Entity;

namespace UniqueIdentifiersBenchmark.Data.Persistence.Contracts
{
    public interface IAuthorRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IAuthor<TKey>
    {
        Task<TEntity> GetWithBooksByIdAsync(TKey id);
    }
}
