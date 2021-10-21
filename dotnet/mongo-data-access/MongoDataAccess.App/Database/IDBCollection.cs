using MongoDataAccess.App.Models;
using MongoDB.Driver;

namespace MongoDataAccess.App.Database;

public interface IDBCollection
{
     IMongoCollection<Toy> Toys { get; }
}