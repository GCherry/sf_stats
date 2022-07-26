using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using sf_stats.DataAccess.MSSql.Context;
using Microsoft.EntityFrameworkCore;
using sf_stats.DataAccess.MSSql.Repositories;
using sf_stats.DataAccess.MSSql.Interfaces;

namespace sf_stats.DataAccess.Extensions.MSSql
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SFStatDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<ISeasonRepository, SeasonRepository>();
            services.AddTransient<IDivisionRepository, DivisionRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ITeamSeasonRepository, TeamSeasonRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<ITeamSeasonGameRepository, TeamSeasonGameRepository>();

            return services;
        }
    }
}
