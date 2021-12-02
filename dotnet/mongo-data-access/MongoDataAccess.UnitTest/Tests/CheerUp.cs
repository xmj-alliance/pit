using MongoDataAccess.App.Database;
using MongoDB.Bson;

namespace MongoDataAccess.UnitTest.Tests;

[Collection("Sequential")]
public class CheerUpTest : IClassFixture<ServiceFixture>, IDisposable
{
    private readonly IHost testHost;
    private readonly IDBContext dbContext;
    public CheerUpTest(ServiceFixture fixture)
    {
        testHost = fixture.TestHost;
        dbContext = testHost.Services.GetRequiredService<IDBContext>();
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