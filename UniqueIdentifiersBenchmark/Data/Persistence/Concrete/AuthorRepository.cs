using Microsoft.EntityFrameworkCore;
using UniqueIdentifiersBenchmark.Data.Entity;
using UniqueIdentifiersBenchmark.Data.Persistence.Contracts;

namespace UniqueIdentifiersBenchmark.Data.Persistence.Concrete
{
    public class AuthorRepository<TEntity, TKey> : Repository<TEntity, TKey>, IAuthorRepository<TEntity, TKey>
        where TEntity : class, IAuthor<TKey>
    {
        public AuthorRepository(ApplicationDbContext context)
            : base(context)
        { }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public async Task<TEntity> GetWithBooksByIdAsync(TKey id)
        {
            return await Context.Set<TEntity>()
                .Include(a => a.Books)
                .SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
    }
}
