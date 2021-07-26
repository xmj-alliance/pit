using DapperORM.App.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DapperORM.UnitTest
{
    public class CheerUp : IClassFixture<ServiceFixture>, IAsyncLifetime
    {
        private readonly ServiceProvider serviceProvider;
        private readonly IDBContext dbContext;

        public CheerUp(ServiceFixture fixture)
        {
            serviceProvider = fixture.ServiceProvider as ServiceProvider;
            dbContext = serviceProvider.GetService<IDBContext>();
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
