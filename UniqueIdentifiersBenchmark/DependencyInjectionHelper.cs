using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UniqueIdentifiersBenchmark.Data;
using UniqueIdentifiersBenchmark.Data.Entity;
using UniqueIdentifiersBenchmark.Data.Persistence;

namespace UniqueIdentifiersBenchmark
{
    public static class DependencyInjectionHelper
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<Program>()
                .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, LogLevel.Information));

            services.AddScoped<ApplicationDbContext>();

            services.AddScoped(typeof(UnitOfWork<,,>));

            //services.AddScoped<
            //    IUnitOfWork<AuthorAsPrimaryKeyInt, BookAsPrimaryKeyInt, int>,
            //    UnitOfWork<AuthorAsPrimaryKeyInt, BookAsPrimaryKeyInt, int>>();

            //services.AddScoped<
            //    IUnitOfWork<AuthorAsPrimaryKeyCuid, BookAsPrimaryKeyCuid, string>,
            //    UnitOfWork<AuthorAsPrimaryKeyCuid, BookAsPrimaryKeyCuid, string>>();

            //services.AddScoped<
            //    IUnitOfWork<AuthorAsPrimaryKeyGuid, BookAsPrimaryKeyGuid, Guid>,
            //    UnitOfWork<AuthorAsPrimaryKeyGuid, BookAsPrimaryKeyGuid, Guid>>();

            //services.AddScoped<
            //    IUnitOfWork<AuthorAsPrimaryKeyNanoid, BookAsPrimaryKeyNanoid, string>,
            //    UnitOfWork<AuthorAsPrimaryKeyNanoid, BookAsPrimaryKeyNanoid, string>>();

            //services.AddScoped<
            //    IUnitOfWork<AuthorAsPrimaryKeyUlid, BookAsPrimaryKeyUlid, Ulid>,
            //    UnitOfWork<AuthorAsPrimaryKeyUlid, BookAsPrimaryKeyUlid, Ulid>>();

            //services.AddScoped<
            //    IUnitOfWork<AuthorWithCuidReferenceId, BookWithCuidReferenceId, int>,
            //    UnitOfWork<AuthorWithCuidReferenceId, BookWithCuidReferenceId, int>>();

            //services.AddScoped<
            //    IUnitOfWork<AuthorWithGuidReferenceId, BookWithGuidReferenceId, int>,
            //    UnitOfWork<AuthorWithGuidReferenceId, BookWithGuidReferenceId, int>>();

            //services.AddScoped<
            //    IUnitOfWork<AuthorWithNanoidReferenceId, BookWithNanoidReferenceId, int>,
            //    UnitOfWork<AuthorWithNanoidReferenceId, BookWithNanoidReferenceId, int>>();

            //services.AddScoped<
            //    IUnitOfWork<AuthorWithUlidReferenceId, BookWithUlidReferenceId, int>,
            //    UnitOfWork<AuthorWithUlidReferenceId, BookWithUlidReferenceId, int>>();

            services.AddScoped<UuidBenchmark>();
        }
    }
}
