using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace sf_stats.DataAccess.Extensions.MSSql
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<Context>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            ////Repositories
            //services.AddTransient<IRepository, Repository>();

            return services;
        }
    }
}
