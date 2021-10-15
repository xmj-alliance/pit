using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

internal class DBContext : IDBContext
{
    private readonly IConfiguration config;
    private MongoClient Client { get; set; }
    private MongoUrl ClientURL { get; set; }
    public IMongoDatabase DBInstance { get; private init; }
    public DBContext(IConfiguration config)
    {
        this.config = config;
        ClientURL = new MongoUrl(config.GetConnectionString("DefaultConnection"));
        Client = new MongoClient(ClientURL.DatabaseName);
        DBInstance = Client.GetDatabase(ClientURL.DatabaseName);
    }
    public bool Drop()
    {
        try
        {
            Client.DropDatabase(ClientURL.DatabaseName);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return false;
        }
    }

}