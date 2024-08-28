namespace UniqueIdentifiersBenchmark.Data.Entity
{
    public class AuthorAsPrimaryKeyInt : AuthorBase<int>
    {
        public new ICollection<BookAsPrimaryKeyInt> Books { get; set; } = [];
    }
    public class AuthorAsPrimaryKeyCuid : AuthorBase<string>
    {
        public new ICollection<BookAsPrimaryKeyCuid> Books { get; set; } = [];
    }
    public class AuthorAsPrimaryKeyGuid : AuthorBase<Guid>
    {
        public new ICollection<BookAsPrimaryKeyGuid> Books { get; set; } = [];
    }
    public class AuthorAsPrimaryKeyNanoid : AuthorBase<string>
    {
        public new ICollection<BookAsPrimaryKeyNanoid> Books { get; set; } = [];
    }
    public class AuthorAsPrimaryKeyUlid : AuthorBase<Ulid>
    {
        public new ICollection<BookAsPrimaryKeyUlid> Books { get; set; } = [];
    }

    public class AuthorWithCuidReferenceId : AuthorReferencedBase<string>
    {
        public new ICollection<BookWithCuidReferenceId> Books { get; set; } = [];
    }
    public class AuthorWithGuidReferenceId : AuthorReferencedBase<Guid>
    {
        public new ICollection<BookWithGuidReferenceId> Books { get; set; } = [];
    }
    public class AuthorWithNanoidReferenceId : AuthorReferencedBase<string>
    {
        public new ICollection<BookWithNanoidReferenceId> Books { get; set; } = [];
    }
    public class AuthorWithUlidReferenceId : AuthorReferencedBase<Ulid>
    {
        public new ICollection<BookWithUlidReferenceId> Books { get; set; } = [];
    }
}
