namespace UniqueIdentifiersBenchmark.Data.Entity
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
    public interface IAuthor<TKey> : IEntity<TKey>
    {
        string Name { get; set; }
        ICollection<IBook<TKey>> Books { get; set; }
    }
    public interface IBook<TKey> : IEntity<TKey>
    {
        string Title { get; set; }
        TKey AuthorId { get; set; }
        IAuthor<TKey> Author { get; set; }
    }
}
