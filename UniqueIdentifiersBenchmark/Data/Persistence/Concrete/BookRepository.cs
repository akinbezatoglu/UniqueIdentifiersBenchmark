using Microsoft.EntityFrameworkCore;
using UniqueIdentifiersBenchmark.Data.Entity;
using UniqueIdentifiersBenchmark.Data.Persistence.Contracts;

namespace UniqueIdentifiersBenchmark.Data.Persistence.Concrete
{
    public class BookRepository<TEntity, TKey> : Repository<TEntity, TKey>, IBookRepository<TEntity, TKey>
        where TEntity : class, IBook<TKey>
    {
        public BookRepository(ApplicationDbContext context) 
            : base(context)
        { }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public async Task<TEntity> GetWithAuthorByIdAsync(TKey id)
        {
            return await Context.Set<TEntity>()
                .Include(b => b.Author)
                .SingleOrDefaultAsync(b => b.Id.Equals(id));
        }
    }
}
