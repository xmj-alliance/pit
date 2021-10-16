using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDataAccess.App.Database;

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

                    // add services
                    //services.AddSingleton<IBookService, BookService>();
            })
            .Build();

    }
}