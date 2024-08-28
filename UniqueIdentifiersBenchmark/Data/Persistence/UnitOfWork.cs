using UniqueIdentifiersBenchmark.Data.Entity;
using UniqueIdentifiersBenchmark.Data.Persistence.Concrete;
using UniqueIdentifiersBenchmark.Data.Persistence.Contracts;

namespace UniqueIdentifiersBenchmark.Data.Persistence
{
    public class UnitOfWork<TAuthor, TBook, TKey> : IUnitOfWork<TAuthor, TBook, TKey>
        where TAuthor : class, IAuthor<TKey>
        where TBook : class, IBook<TKey>
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private AuthorRepository<TAuthor, TKey> _authorRepository;
        private BookRepository<TBook, TKey> _bookRepository;

        public IAuthorRepository<TAuthor, TKey> AuthorRepository =>
            _authorRepository ??= new AuthorRepository<TAuthor, TKey>(_context);
        public IBookRepository<TBook, TKey> BookRepository =>
            _bookRepository ??= new BookRepository<TBook, TKey>(_context);

        //private AuthorRepository<AuthorAsPrimaryKeyInt, int> _authorAsPrimaryKeyIntRepository;
        //private AuthorRepository<AuthorAsPrimaryKeyCuid, string> _authorAsPrimaryKeyCuidRepository;
        //private AuthorRepository<AuthorAsPrimaryKeyGuid, Guid> _authorAsPrimaryKeyGuidRepository;
        //private AuthorRepository<AuthorAsPrimaryKeyNanoid, string> _authorAsPrimaryKeyNanoidRepository;
        //private AuthorRepository<AuthorAsPrimaryKeyUlid, Ulid> _authorAsPrimaryKeyUlidRepository;

        //private AuthorRepository<AuthorWithCuidReferenceId, int> _authorWithCuidReferenceIdRepository;
        //private AuthorRepository<AuthorWithGuidReferenceId, int> _authorWithGuidReferenceIdRepository;
        //private AuthorRepository<AuthorWithNanoidReferenceId, int> _authorWithNanoidReferenceIdRepository;
        //private AuthorRepository<AuthorWithUlidReferenceId, int> _authorWithUlidReferenceIdRepository;

        //private BookRepository<BookAsPrimaryKeyInt, int> _bookAsPrimaryKeyIntRepository;
        //private BookRepository<BookAsPrimaryKeyCuid, string> _bookAsPrimaryKeyCuidRepository;
        //private BookRepository<BookAsPrimaryKeyGuid, Guid> _bookAsPrimaryKeyGuidRepository;
        //private BookRepository<BookAsPrimaryKeyNanoid, string> _bookAsPrimaryKeyNanoidRepository;
        //private BookRepository<BookAsPrimaryKeyUlid, Ulid> _bookAsPrimaryKeyUlidRepository;

        //private BookRepository<BookWithCuidReferenceId, int> _bookWithCuidReferenceIdRepository;
        //private BookRepository<BookWithGuidReferenceId, int> _bookWithGuidReferenceIdRepository;
        //private BookRepository<BookWithNanoidReferenceId, int> _bookWithNanoidReferenceIdRepository;
        //private BookRepository<BookWithUlidReferenceId, int> _bookWithUlidReferenceIdRepository;

        //public IAuthorRepository<AuthorAsPrimaryKeyInt, int> AuthorAsPrimaryKeyIntRepository =>
        //    _authorAsPrimaryKeyIntRepository ??= new AuthorRepository<AuthorAsPrimaryKeyInt, int>(_context);
        //public IAuthorRepository<AuthorAsPrimaryKeyCuid, string> AuthorAsPrimaryKeyCuidRepository =>
        //    _authorAsPrimaryKeyCuidRepository ??= new AuthorRepository<AuthorAsPrimaryKeyCuid, string>(_context);
        //public IAuthorRepository<AuthorAsPrimaryKeyGuid, Guid> AuthorAsPrimaryKeyGuidRepository =>
        //    _authorAsPrimaryKeyGuidRepository ??= new AuthorRepository<AuthorAsPrimaryKeyGuid, Guid>(_context);
        //public IAuthorRepository<AuthorAsPrimaryKeyNanoid, string> AuthorAsPrimaryKeyNanoidRepository =>
        //    _authorAsPrimaryKeyNanoidRepository ??= new AuthorRepository<AuthorAsPrimaryKeyNanoid, string>(_context);
        //public IAuthorRepository<AuthorAsPrimaryKeyUlid, Ulid> AuthorAsPrimaryKeyUlidRepository =>
        //    _authorAsPrimaryKeyUlidRepository ??= new AuthorRepository<AuthorAsPrimaryKeyUlid, Ulid>(_context);

        //public IAuthorRepository<AuthorWithCuidReferenceId, int> AuthorWithCuidReferenceIdRepository =>
        //    _authorWithCuidReferenceIdRepository ??= new AuthorRepository<AuthorWithCuidReferenceId, int>(_context);
        //public IAuthorRepository<AuthorWithGuidReferenceId, int> AuthorWithGuidReferenceIdRepository =>
        //    _authorWithGuidReferenceIdRepository ??= new AuthorRepository<AuthorWithGuidReferenceId, int>(_context);
        //public IAuthorRepository<AuthorWithNanoidReferenceId, int> AuthorWithnNanoidReferenceIdRepository =>
        //    _authorWithNanoidReferenceIdRepository ??= new AuthorRepository<AuthorWithNanoidReferenceId, int>(_context);
        //public IAuthorRepository<AuthorWithUlidReferenceId, int> AuthorWithUlidReferenceIdRepository =>
        //    _authorWithUlidReferenceIdRepository ??= new AuthorRepository<AuthorWithUlidReferenceId, int>(_context);

        //public IBookRepository<BookAsPrimaryKeyInt, int> BookAsPrimaryKeyIntRepository =>
        //    _bookAsPrimaryKeyIntRepository ??= new BookRepository<BookAsPrimaryKeyInt, int>(_context);
        //public IBookRepository<BookAsPrimaryKeyCuid, string> BookAsPrimaryKeyCuidRepository =>
        //    _bookAsPrimaryKeyCuidRepository ??= new BookRepository<BookAsPrimaryKeyCuid, string>(_context);
        //public IBookRepository<BookAsPrimaryKeyGuid, Guid> BookAsPrimaryKeyGuidRepository =>
        //    _bookAsPrimaryKeyGuidRepository ??= new BookRepository<BookAsPrimaryKeyGuid, Guid>(_context);
        //public IBookRepository<BookAsPrimaryKeyNanoid, string> BookAsPrimaryKeyNanoidRepository =>
        //    _bookAsPrimaryKeyNanoidRepository ??= new BookRepository<BookAsPrimaryKeyNanoid, string>(_context);
        //public IBookRepository<BookAsPrimaryKeyUlid, Ulid> BookAsPrimaryKeyUlidRepository =>
        //    _bookAsPrimaryKeyUlidRepository ??= new BookRepository<BookAsPrimaryKeyUlid, Ulid>(_context);

        //public IBookRepository<BookWithCuidReferenceId, int> BookWithCuidReferenceIdRepository =>
        //    _bookWithCuidReferenceIdRepository ??= new BookRepository<BookWithCuidReferenceId, int>(_context);
        //public IBookRepository<BookWithGuidReferenceId, int> BookWithGuidReferenceIdRepository =>
        //    _bookWithGuidReferenceIdRepository ??= new BookRepository<BookWithGuidReferenceId, int>(_context);
        //public IBookRepository<BookWithNanoidReferenceId, int> BookWithnNanoidReferenceIdRepository =>
        //    _bookWithNanoidReferenceIdRepository ??= new BookRepository<BookWithNanoidReferenceId, int>(_context);
        //public IBookRepository<BookWithUlidReferenceId, int> BookWithUlidReferenceIdRepository =>
        //    _bookWithUlidReferenceIdRepository ??= new BookRepository<BookWithUlidReferenceId, int>(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
