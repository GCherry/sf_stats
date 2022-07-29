using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using sf_stats.DataAccess.MSSql.Context;
using Microsoft.EntityFrameworkCore;
using sf_stats.DataAccess.MSSql.Repositories;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.Entities;
using sf_stats.Domain.DomainObjects;

namespace sf_stats.DataAccess.Extensions.MSSql
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SFStatDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<ICrudRepository<Season, SeasonQueryFilter>, SeasonRepository>();
            services.AddTransient<ICrudRepository<Division, DivisionQueryFilter>, DivisionRepository>();
            services.AddTransient<ICrudRepository<Player, PlayerQueryFilter>, PlayerRepository>();
            services.AddTransient<ICrudRepository<Team, TeamQueryFilter>, TeamRepository>();
            services.AddTransient<ICrudRepository<TeamSeason, TeamSeasonQueryFilter>, TeamSeasonRepository>();
            services.AddTransient<ICrudRepository<Game, GameQueryFilter>, GameRepository>();
            services.AddTransient<ICrudRepository<TeamSeasonGame, TeamSeasonGameQueryFilter>, TeamSeasonGameRepository>();

            return services;
        }
    }
}
