using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        // configure db
        //services.AddTransient<IDBContext, DBContext>();

        // services
        //services.AddSingleton<IBookService, BookService>();
    })
    .Build();