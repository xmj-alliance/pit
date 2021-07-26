using DapperORM.App.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.UnitTest
{
    public class ServiceFixture
    {
        public IServiceProvider ServiceProvider { get; }

        public ServiceFixture()
        {

            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
            //    .AddEnvironmentVariables()
            //    .Build();

            var services = new ServiceCollection();

            // config db
            services.AddTransient<IDBContext, DBContext>();

            // add services
            //services.AddSingleton<INexusService, NexusService>();

            ServiceProvider = services.BuildServiceProvider();
        }

    }
}
