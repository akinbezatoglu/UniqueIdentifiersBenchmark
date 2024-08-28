namespace UniqueIdentifiersBenchmark.Data.Entity
{
    public class BookAsPrimaryKeyInt : BookBase<int>
    {
        public new AuthorAsPrimaryKeyInt Author { get; set; }
    }
    public class BookAsPrimaryKeyCuid : BookBase<string>
    {
        public new AuthorAsPrimaryKeyCuid Author { get; set; }
    }
    public class BookAsPrimaryKeyGuid : BookBase<Guid>
    {
        public new AuthorAsPrimaryKeyGuid Author { get; set; }
    }
    public class BookAsPrimaryKeyNanoid : BookBase<string>
    {
        public new AuthorAsPrimaryKeyNanoid Author { get; set; }
    }
    public class BookAsPrimaryKeyUlid : BookBase<Ulid>
    {
        public new AuthorAsPrimaryKeyUlid Author { get; set; }
    }

    public class BookWithCuidReferenceId : BookReferencedBase<string>
    {
        public new AuthorWithCuidReferenceId Author { get; set; }
    }
    public class BookWithGuidReferenceId : BookReferencedBase<Guid>
    {
        public new AuthorWithGuidReferenceId Author { get; set; }
    }
    public class BookWithNanoidReferenceId : BookReferencedBase<string>
    {
        public new AuthorWithNanoidReferenceId Author { get; set; }
    }
    public class BookWithUlidReferenceId : BookReferencedBase<Ulid>
    {
        public new AuthorWithUlidReferenceId Author { get; set; }
    }
}
