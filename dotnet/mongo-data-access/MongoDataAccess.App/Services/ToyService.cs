using MongoDataAccess.App.Database;
using MongoDataAccess.App.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDataAccess.App.Services;

public class ToyService : DataAccessService<Toy>, IToyService
{
    private readonly string dbnamePrefix = "toy";
    private readonly IMongoCollection<Toy> collection;
    public ToyService(IDBCollection collections) : base(
        collection: collections.Toys
    )
    { collection = collections.Toys; }

    public async Task<InstanceCUDMessage<Toy>> Add(InputToy newToy)
    {
        try
        {
            var toy = new Toy(
                ID: ObjectId.GenerateNewId().ToString(),
                DBName: string.IsNullOrWhiteSpace(newToy.DBName) ? $"{ dbnamePrefix }-{ Guid.NewGuid() }" : newToy.DBName,
                Name: newToy.Name ?? "",
                Description: newToy.Description ?? "",
                UpdateDate: DateTime.Now,
                DeleteDate: null,
                HasAgeLimit: newToy.HasAgeLimit ?? true,
                Price: newToy.Price ?? 0
            );

            await collection.InsertOneAsync(toy);

            return new InstanceCUDMessage<Toy>(
                OK: true,
                NumAffected: 1,
                Message: "",
                Instances: new List<Toy>() { toy }
            );
        }
        catch (Exception e)
        {
            return new InstanceCUDMessage<Toy>(
                OK: false,
                NumAffected: 0,
                Message: e.Message,
                Instances: null
            );
        }
    }

    public async Task<InstanceCUDMessage<Toy>> Add(IEnumerable<InputToy> newToys)
    {

        try
        {
            var toys = (
                from toy in newToys
                select new Toy(
                    ID: ObjectId.GenerateNewId().ToString(),
                    DBName: string.IsNullOrWhiteSpace(toy.DBName) ? $"{ dbnamePrefix }-{ Guid.NewGuid() }" : toy.DBName,
                    Name: toy.Name ?? "",
                    Description: toy.Description ?? "",
                    UpdateDate: DateTime.Now,
                    DeleteDate: null,
                    HasAgeLimit: toy.HasAgeLimit ?? true,
                    Price: toy.Price ?? 0
                )
            );

            await collection.InsertManyAsync(toys);

            return new InstanceCUDMessage<Toy>(
                OK: true,
                NumAffected: toys.Count(),
                Message: "",
                Instances: toys
            );

        }
        catch (Exception e)
        {
            return new InstanceCUDMessage<Toy>(
                OK: false,
                NumAffected: 0,
                Message: e.Message,
                Instances: null
            );
        }

    }
}

