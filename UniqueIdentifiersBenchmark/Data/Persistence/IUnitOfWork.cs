using UniqueIdentifiersBenchmark.Data.Entity;
using UniqueIdentifiersBenchmark.Data.Persistence.Contracts;

namespace UniqueIdentifiersBenchmark.Data.Persistence
{
    public interface IUnitOfWork<TAuthor, TBook, TKey> : IDisposable
        where TAuthor : class, IAuthor<TKey>
        where TBook : class, IBook<TKey>
    {
        IAuthorRepository<TAuthor, TKey> AuthorRepository { get; }
        IBookRepository<TBook, TKey> BookRepository { get; }

        //IAuthorRepository<AuthorAsPrimaryKeyInt, int> AuthorAsPrimaryKeyIntRepository { get; }
        //IAuthorRepository<AuthorAsPrimaryKeyCuid, string> AuthorAsPrimaryKeyCuidRepository { get; }
        //IAuthorRepository<AuthorAsPrimaryKeyGuid, Guid> AuthorAsPrimaryKeyGuidRepository { get; }
        //IAuthorRepository<AuthorAsPrimaryKeyNanoid, string> AuthorAsPrimaryKeyNanoidRepository { get; }
        //IAuthorRepository<AuthorAsPrimaryKeyUlid, Ulid> AuthorAsPrimaryKeyUlidRepository { get; }

        //IBookRepository<BookAsPrimaryKeyInt, int> BookAsPrimaryKeyIntRepository { get; }
        //IBookRepository<BookAsPrimaryKeyCuid, string> BookAsPrimaryKeyCuidRepository { get; }
        //IBookRepository<BookAsPrimaryKeyGuid, Guid> BookAsPrimaryKeyGuidRepository { get; }
        //IBookRepository<BookAsPrimaryKeyNanoid, string> BookAsPrimaryKeyNanoidRepository { get; }
        //IBookRepository<BookAsPrimaryKeyUlid, Ulid> BookAsPrimaryKeyUlidRepository { get; }

        Task<int> CommitAsync();
    }
}
