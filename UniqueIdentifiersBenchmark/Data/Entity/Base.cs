namespace UniqueIdentifiersBenchmark.Data.Entity
{
    public abstract class AuthorBase<TKey> : IEntity<TKey>, IAuthor<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public ICollection<IBook<TKey>> Books { get; set; }
    }
    public class AuthorReferencedBase<TKey> : AuthorBase<int>
    {
        public TKey ReferenceId { get; set; }
    }
    public class BookBase<TKey> : IEntity<TKey>, IBook<TKey>
    {
        public TKey Id { get; set; }
        public string Title { get; set; }
        public TKey AuthorId { get; set; }
        public IAuthor<TKey> Author { get; set; }
    }
    public class BookReferencedBase<TKey> : BookBase<int>
    {
        public TKey ReferenceId { get; set; }
    }
}
