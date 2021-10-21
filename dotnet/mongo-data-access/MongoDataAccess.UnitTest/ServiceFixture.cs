using MongoDataAccess.App.Database;
using MongoDataAccess.App.Services;

namespace MongoDataAccess.UnitTest;

public class ServiceFixture
{
    public IHost TestHost { get; set; }

    public ServiceFixture()
    {

        TestHost = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // configure db
                services.AddTransient<IDBContext, DBContext>();
                services.AddTransient<IDBCollection, DBCollection>();

                // add services
                services.AddSingleton<IToyService, ToyService>();
            })
            .Build();

    }
}