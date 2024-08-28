using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Jobs;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using NanoidDotNet;
using UniqueIdentifiersBenchmark.Data.Entity;
using UniqueIdentifiersBenchmark.Data.Persistence;
using Visus.Cuid;

namespace UniqueIdentifiersBenchmark
{
    [MemoryDiagnoser]
    [SimpleJob(runtimeMoniker: RuntimeMoniker.Net80)]
    [HideColumns(Column.Error, Column.Median, Column.StdDev, Column.StdErr, Column.Gen0, Column.Gen1, Column.Gen2)]
    public class UuidBenchmark
    {
        private UnitOfWork<AuthorAsPrimaryKeyInt, BookAsPrimaryKeyInt, int> _unitOfWorkPrimaryKeyInt;
        private UnitOfWork<AuthorAsPrimaryKeyCuid, BookAsPrimaryKeyCuid, string> _unitOfWorkPrimaryKeyCuid;
        private UnitOfWork<AuthorAsPrimaryKeyGuid, BookAsPrimaryKeyGuid, Guid> _unitOfWorkPrimaryKeyGuid;
        private UnitOfWork<AuthorAsPrimaryKeyNanoid, BookAsPrimaryKeyNanoid, string> _unitOfWorkPrimaryKeyNanoid;
        private UnitOfWork<AuthorAsPrimaryKeyUlid, BookAsPrimaryKeyUlid, Ulid> _unitOfWorkPrimaryKeyUlid;

        private readonly int fakerSeed = 1024;
        private List<AuthorAsPrimaryKeyInt> authorsAsPrimaryKeyInt;
        private List<AuthorAsPrimaryKeyCuid> authorsAsPrimaryKeyCuid;
        private List<AuthorAsPrimaryKeyGuid> authorsAsPrimaryKeyGuid;
        private List<AuthorAsPrimaryKeyNanoid> authorsAsPrimaryKeyNanoid;
        private List<AuthorAsPrimaryKeyUlid> authorsAsPrimaryKeyUlid;

        [GlobalSetup]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            _unitOfWorkPrimaryKeyInt = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyInt, BookAsPrimaryKeyInt, int>>();
            _unitOfWorkPrimaryKeyCuid = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyCuid, BookAsPrimaryKeyCuid, string>>();
            _unitOfWorkPrimaryKeyGuid = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyGuid, BookAsPrimaryKeyGuid, Guid>>();
            _unitOfWorkPrimaryKeyNanoid = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyNanoid, BookAsPrimaryKeyNanoid, string>>();
            _unitOfWorkPrimaryKeyUlid = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyUlid, BookAsPrimaryKeyUlid, Ulid>>();

            authorsAsPrimaryKeyInt = new Faker<AuthorAsPrimaryKeyInt>()
                .UseSeed(fakerSeed)
                .RuleFor(i => i.Name, i => i.Person.FullName)
                .Generate(10);

            authorsAsPrimaryKeyCuid = new Faker<AuthorAsPrimaryKeyCuid>()
                .UseSeed(fakerSeed)
                .RuleFor(i => i.Id, i => new Cuid2().ToString())
                .RuleFor(i => i.Name, i => i.Person.FullName)
                .Generate(10);

            authorsAsPrimaryKeyGuid = new Faker<AuthorAsPrimaryKeyGuid>()
                .UseSeed(fakerSeed)
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.Name, i => i.Person.FullName)
                .Generate(10);

            authorsAsPrimaryKeyNanoid = new Faker<AuthorAsPrimaryKeyNanoid>()
                .UseSeed(fakerSeed)
                .RuleFor(i => i.Id, i => Nanoid.Generate(Nanoid.Alphabets.LettersAndDigits))
                .RuleFor(i => i.Name, i => i.Person.FullName)
                .Generate(10);

            authorsAsPrimaryKeyUlid = new Faker<AuthorAsPrimaryKeyUlid>()
                .UseSeed(fakerSeed)
                .RuleFor(i => i.Id, i => Ulid.NewUlid())
                .RuleFor(i => i.Name, i => i.Person.FullName)
                .Generate(10);
        }

        [Benchmark]
        public async Task AddRangeAuthorAsPrimaryKeyInt()
        {
            await _unitOfWorkPrimaryKeyInt.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyInt);
        }
        [Benchmark]
        public async Task AddRangeAuthorAsPrimaryKeyCuid()
        {
            await _unitOfWorkPrimaryKeyCuid.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyCuid);
        }
        [Benchmark]
        public async Task AddRangeAuthorAsPrimaryKeyGuid()
        {
            await _unitOfWorkPrimaryKeyGuid.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyGuid);
        }
        [Benchmark]
        public async Task AddRangeAuthorAsPrimaryKeyNanoid()
        {
            await _unitOfWorkPrimaryKeyNanoid.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyNanoid);
        }
        [Benchmark]
        public async Task AddRangeAuthorAsPrimaryKeyUlid()
        {
            await _unitOfWorkPrimaryKeyUlid.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyUlid);
        }
    }
}
