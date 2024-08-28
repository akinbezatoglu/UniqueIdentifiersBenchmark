using BenchmarkDotNet.Running;
using UniqueIdentifiersBenchmark;

_ = BenchmarkRunner.Run<UuidBenchmark>();

//var services = new ServiceCollection();
//services.ConfigureServices();

//var serviceProvider = services.BuildServiceProvider();

//var _unitOfWorkPrimaryKeyInt = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyInt, BookAsPrimaryKeyInt, int>>();
//var _unitOfWorkPrimaryKeyCuid = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyCuid, BookAsPrimaryKeyCuid, string>>();
//var _unitOfWorkPrimaryKeyGuid = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyGuid, BookAsPrimaryKeyGuid, Guid>>();
//var _unitOfWorkPrimaryKeyNanoid = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyNanoid, BookAsPrimaryKeyNanoid, string>>();
//var _unitOfWorkPrimaryKeyUlid = serviceProvider.GetRequiredService<UnitOfWork<AuthorAsPrimaryKeyUlid, BookAsPrimaryKeyUlid, Ulid>>();

//int fakerSeed = 1024;

//var authorsAsPrimaryKeyInt = new Faker<AuthorAsPrimaryKeyInt>()
//    .UseSeed(fakerSeed)
//    .RuleFor(i => i.Name, i => i.Person.FullName)
//    .Generate(10);

//var authorsAsPrimaryKeyCuid = new Faker<AuthorAsPrimaryKeyCuid>()
//    .UseSeed(fakerSeed)
//    .RuleFor(i => i.Id, i => new Cuid2().ToString())
//    .RuleFor(i => i.Name, i => i.Person.FullName)
//    .Generate(10);

//var authorsAsPrimaryKeyGuid = new Faker<AuthorAsPrimaryKeyGuid>()
//    .UseSeed(fakerSeed)
//    .RuleFor(i => i.Id, i => Guid.NewGuid())
//    .RuleFor(i => i.Name, i => i.Person.FullName)
//    .Generate(10);

//var authorsAsPrimaryKeyNanoid = new Faker<AuthorAsPrimaryKeyNanoid>()
//    .UseSeed(fakerSeed)
//    .RuleFor(i => i.Id, i => Nanoid.Generate(Nanoid.Alphabets.LettersAndDigits))
//    .RuleFor(i => i.Name, i => i.Person.FullName)
//    .Generate(10);

//var authorsAsPrimaryKeyUlid = new Faker<AuthorAsPrimaryKeyUlid>()
//    .UseSeed(fakerSeed)
//    .RuleFor(i => i.Id, i => Ulid.NewUlid())
//    .RuleFor(i => i.Name, i => i.Person.FullName)
//    .Generate(10);

//await _unitOfWorkPrimaryKeyInt.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyInt);
//await _unitOfWorkPrimaryKeyCuid.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyCuid);
//await _unitOfWorkPrimaryKeyGuid.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyGuid);
//await _unitOfWorkPrimaryKeyNanoid.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyNanoid);
//await _unitOfWorkPrimaryKeyUlid.AuthorRepository.AddRangeAsync(authorsAsPrimaryKeyUlid);
