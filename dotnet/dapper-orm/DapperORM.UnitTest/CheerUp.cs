using DapperORM.App.Database;
using DapperORM.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DapperORM.UnitTest
{
    public class CheerUp : IClassFixture<ServiceFixture>, IAsyncLifetime
    {
        private readonly IDBContext dbContext;
        private readonly IHost testHost;

        public CheerUp(ServiceFixture fixture)
        {
            testHost = fixture.TestHost;
            dbContext = testHost.Services.GetService<IDBContext>();
        }

        [Fact]
        public void HaveFun()
        {
            Assert.Equal("😙", "😙");
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            // called after each test method
            await dbContext.Drop();
            await dbContext.Create();
        }
    }

}
