using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDataAccess.App.Database;

namespace MongoDataAccess.UnitTest.Tests;

[Collection("Sequential")]
public class CheerUpTest : IClassFixture<ServiceFixture>, IDisposable
{
    private readonly IHost testHost;
    private readonly IDBContext dbContext;
    public CheerUpTest(ServiceFixture fixture)
    {
        testHost = fixture.TestHost;
        var _dbContext = testHost.Services.GetService<IDBContext>();
        if (_dbContext is null)
        {
            throw new Exception("DBContext is incorrectly configured. Received null.");
        }
        dbContext = _dbContext;
    }
    [Fact]
    public void HaveFun()
    {
        Assert.Equal("🤣", "🤣");
    }

    public void Dispose()
    {
        dbContext.Drop();
        GC.SuppressFinalize(this);
    }
}