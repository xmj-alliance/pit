using MongoDataAccess.App.Database;
using MongoDataAccess.App.Models;
using MongoDataAccess.App.Services;
using MongoDB.Driver;
using Xunit.Sdk;

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

    [Theory(DisplayName = "Toy Crud Single")]
    [ClassData(typeof(Toy_Data_CRUDSingle))]
    public async void CRUDSingle(InputToy newToy)
    {
        // Create
        InstanceCUDMessage<Toy> addMessage = await toyService.Add(newToy);
        Assert.True(addMessage.OK);

        //Assert.NotNull(addMessage.Instances);
        if (addMessage.Instances is null)
        {
            throw new NotNullException();
        }

        Toy addedItem = addMessage.Instances.First();
        Assert.False(string.IsNullOrWhiteSpace(addedItem.ID));

        // Update
        var newPrice = 7.2m;
        var updateToken = Builders<Toy>.Update.Set("price", newPrice);

        CUDMessage updateMessage = await toyService.Update(addedItem.DBName, updateToken);
        Assert.True(updateMessage.OK);

        var updatedItem = await toyService.Get(addedItem.DBName);
        Assert.Equal(newPrice, updatedItem.Price);

        // Delete
        CUDMessage deleteMessage = await toyService.Delete(addedItem.DBName);
        Assert.True(deleteMessage.OK);

        var deletedItem = await toyService.Get(addedItem.DBName);
        Assert.NotNull(deletedItem.DeleteDate);

        // Drop
        CUDMessage dropMessage = await toyService.Drop(addedItem.DBName);
        Assert.True(dropMessage.OK);

        var droppedItem = await toyService.Get(addedItem.DBName);
        Assert.Null(droppedItem);

    }

    [Theory(DisplayName = "Toy Crud Multiple")]
    [ClassData(typeof(Toy_Data_CRUDMultiple))]
    public async void CRUDMultiple(List<InputToy> newToys)
    {
        // Create
        InstanceCUDMessage<Toy> addMessage = await toyService.Add(newToys);
        Assert.True(addMessage.OK);

        if (addMessage.Instances is null)
        {
            throw new NotNullException();
        }

        foreach (var item in addMessage.Instances)
        {
            Assert.False(string.IsNullOrWhiteSpace(item.ID));
        }

        // Update
        var newName = "[Item hidden to you, kid]";
        var updateCondition = Builders<Toy>.Filter.Eq("hasAgeLimit", true);
        var updateToken = Builders<Toy>.Update.Set("name", newName);

        CUDMessage updateMessage = await toyService.Update(updateCondition, updateToken);
        Assert.True(updateMessage.OK);

        var updatedItems = await toyService.Get(updateCondition);
        foreach (var item in updatedItems)
        {
            Assert.Equal(newName, item.Name);
        }

        // Delete
        var deleteCondition = Builders<Toy>.Filter.Eq("hasAgeLimit", true);
        CUDMessage deleteMessage = await toyService.Delete(deleteCondition);
        Assert.True(deleteMessage.OK);

        var deletedItem = await toyService.Get(deleteCondition);
        foreach (var item in deletedItem)
        {
            Assert.NotNull(item.DeleteDate);
        }

        // Drop
        CUDMessage dropMessage = await toyService.Drop(deleteCondition);
        Assert.True(dropMessage.OK);

        var droppedItem = await toyService.Get(deleteCondition);
        Assert.Empty(droppedItem);

    }

    public void Dispose()
    {
        dbContext.Drop();
        GC.SuppressFinalize(this);
    }
}

public class Toy_Data_CRUDSingle : TheoryData<InputToy>
{
    public Toy_Data_CRUDSingle() => Add(
        new InputToy(
            DBName: "toy-miniHorse",
            Name: "Mini Horse",
            Description: "Mini Horse",
            HasAgeLimit: false,
            Price: 6.3m
        )
    );
}

public class Toy_Data_CRUDMultiple : TheoryData<List<InputToy>>
{
    public Toy_Data_CRUDMultiple() => Add(
        new List<InputToy>()
        {
            new InputToy(
                DBName: "toy-superSoldierSet",
                Name: "Super Soldier Set",
                Description: "Super Soldier Set",
                HasAgeLimit: false,
                Price: 19.9m
            ),
            new InputToy(
                DBName: "toy-lionQueenModel",
                Name: "Lion Queen Model",
                Description: "Lion Queen Model",
                HasAgeLimit: true,
                Price: 99.99m
            ),
            new InputToy(
                DBName: "toy-x101RacingCar",
                Name: "X101 Racing Car",
                Description: "X101 Racing Car",
                HasAgeLimit: true,
                Price: 399.99m
            ),
        }
    );
}