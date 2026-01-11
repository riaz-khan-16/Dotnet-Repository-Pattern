


using Repository_Pattern.Models;
using Repository_Pattern.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Repository_Pattern.Services
{
    public static  class DependencyInjection
    {

     
            public static IServiceCollection AddInfrastructureServices(
                this IServiceCollection services,
                IConfiguration configuration)
            {
                // MongoDB settings - manual binding
                var mongoSettings = new MongoSetting();
                configuration.GetSection("MongoDB").Bind(mongoSettings);
                services.AddSingleton(mongoSettings);

                // Or use IOptions pattern
                services.Configure<MongoSetting>(options =>
                {
                    configuration.GetSection("MongoDB").Bind(options);
                });

                // MongoDB Context
                services.AddSingleton<IDBService, DBService>();

                return services;
            }
        


    }
}
