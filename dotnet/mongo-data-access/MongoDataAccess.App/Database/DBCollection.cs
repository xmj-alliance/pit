using MongoDataAccess.App.Models;
using MongoDB.Driver;

namespace MongoDataAccess.App.Database;

public class DBCollection: IDBCollection
{
    private readonly IDBContext context;

    public DBCollection(IDBContext context)
    {
        this.context = context;
    }

    public IMongoCollection<Toy> Toys => context.DBInstance.GetCollection<Toy>("toys");
    public IMongoCollection<Partner> Partners => context.DBInstance.GetCollection<Partner>("partners");
    public IMongoCollection<StoredCustomer> Customers => context.DBInstance.GetCollection<StoredCustomer>("customers");

}