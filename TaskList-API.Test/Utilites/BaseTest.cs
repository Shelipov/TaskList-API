using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Net.Http;
using TaskList.DAL.DataBase.Context;

namespace TaskList_API.Test.Utilites
{
    public abstract class BaseTest : IDisposable
    {
        private readonly DbContextOptions<TaskListContext> _options;
        private TestServer _server;
        protected HttpClient _client;
        protected TaskListContext _context;

        public BaseTest()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json")
                .Build();

            _options = new DbContextOptionsBuilder<TaskListContext>()
                .UseNpgsql(builder.GetConnectionString("DefaultConnection"))
                .Options;

            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Test")
                .UseConfiguration(builder)
                .UseStartup<Startup>());

            _client = _server.CreateClient();

            _context = new TaskListContext(_options);
            _context.Database.EnsureDeleted();
            _client.BaseAddress = _server.BaseAddress;
            _context.Database.Migrate();
            TaskListSetup.InitializeDbForTests(_context);
        }

        public void Dispose()
        {
            _client.Dispose();
            _context.Database.EnsureDeleted();
            _context.Dispose();
            _server.Dispose();
        }
    }
}
