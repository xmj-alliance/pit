using MongoDB.Driver;

namespace MongoDataAccess.App.Database;

internal class DBCollection: IDBCollection
{
    private readonly IDBContext context;

    public DBCollection(IDBContext context)
    {
        this.context = context;
    }

    // public IMongoCollection<Nexus> Nexuses => context.DBInstance.GetCollection<Nexus>("nexuses");

}