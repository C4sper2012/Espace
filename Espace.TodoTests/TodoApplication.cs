using System;
using Espace;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TodoTests
{
    public class TodoApplication : WebApplicationFactory<Program>, IAsyncDisposable
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            InMemoryDatabaseRoot root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<TodoDb>));

                services.AddDbContext<TodoDb>(options =>
                    InMemoryDbContextOptionsExtensions.UseInMemoryDatabase(options, "Testing", root));
            });

            return base.CreateHost(builder);
        }
    }
}