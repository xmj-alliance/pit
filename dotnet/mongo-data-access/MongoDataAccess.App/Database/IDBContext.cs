using MongoDB.Driver;

namespace MongoDataAccess.App.Database;

public interface IDBContext
{
    IMongoDatabase DBInstance { get; }
    bool Drop();
}
