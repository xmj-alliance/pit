using MongoDB.Driver;

internal interface IDBContext
{
    IMongoDatabase DBInstance { get; }
    bool Drop();
}
