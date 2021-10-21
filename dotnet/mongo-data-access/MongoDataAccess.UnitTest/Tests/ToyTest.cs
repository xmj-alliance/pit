using MongoDataAccess.App.Database;
using MongoDataAccess.App.Library;
using MongoDataAccess.App.Models;
using MongoDataAccess.App.Services;
using MongoDB.Driver;

namespace MongoDataAccess.UnitTest.Tests;

[Collection("Sequential")]
public class ToyTest : IClassFixture<ServiceFixture>, IDisposable
{
    private readonly IHost testHost;
    private readonly IDBContext dbContext;
    private readonly IToyService toyService;

    public ToyTest(ServiceFixture fixture)
    {
        testHost = fixture.TestHost;
        dbContext = testHost.Services.GetRequiredService<IDBContext>();
        toyService = testHost.Services.GetRequiredService<IToyService>();
    }

    [Theory(DisplayName = "Toy Crud Single Test")]
    [ClassData(typeof(Toy_Data_CRUDSingle))]
    public async void CRUDSingle(InputToy newToy)
    {
        // Create
        InstanceCUDMessage<Toy> addMessage = await toyService.Add(newToy);
        Assert.True(addMessage.OK);
        Assert.NotNull(addMessage.Instances);

#pragma warning disable CS8604 // Possible null reference argument.
        Toy addedItem = addMessage.Instances.First();
#pragma warning restore CS8604 // Possible null reference argument.
        Assert.False(string.IsNullOrWhiteSpace(addedItem.ID));

        // Update
        var newPrice = 7.2m;
        var updateCondition = Builders<Toy>.Filter.Eq("dbname", addedItem.DBName);
        var updateToken = Builders<Toy>.Update.Set("price", newPrice);

        CUDMessage updateMessage = await toyService.Update(updateCondition, updateToken);
        Assert.True(updateMessage.OK);

        var updatedItem = await toyService.Get(addedItem.DBName);
        Assert.Equal(newPrice, updatedItem.Price);

        CUDMessage deleteMessage = await toyService.Delete(addedItem.DBName);
        Assert.True(deleteMessage.OK);

        var deletedItem = await toyService.Get(addedItem.DBName);
        Assert.NotNull(deletedItem.DeleteDate);

        CUDMessage dropMessage = await toyService.Drop(addedItem.DBName);
        Assert.True(dropMessage.OK);

        var droppedItem = await toyService.Get(addedItem.DBName);
        Assert.Null(droppedItem);

    }

    public void Dispose()
    {
        dbContext.Drop();
        GC.SuppressFinalize(this);
    }
}

public class Toy_Data_CRUDSingle : TheoryData<InputToy>
{
    public Toy_Data_CRUDSingle()
    {
        Add(new InputToy(
            DBName: "toy-miniHorse",
            Name: "Mini Horse",
            Description: "Mini Horse",
            HasAgeLimit: false,
            Price: 6.3m
        ));
    }
}