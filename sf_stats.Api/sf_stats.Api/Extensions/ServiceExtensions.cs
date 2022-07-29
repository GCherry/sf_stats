using Microsoft.Extensions.DependencyInjection;
using sf_stats.Api.Interfaces;
using sf_stats.Api.Services;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;

namespace sf_stats.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<ILogService, LogService>();

            services.AddTransient<ICrudService<Division, DivisionQueryFilter>, CrudService<Division, DivisionQueryFilter, ICrudRepository<Division, DivisionQueryFilter>>>();
            services.AddTransient<ICrudService<Season, SeasonQueryFilter>, CrudService<Season, SeasonQueryFilter, ICrudRepository<Season, SeasonQueryFilter>>>();
            services.AddTransient<ICrudService<Player, PlayerQueryFilter>, CrudService<Player, PlayerQueryFilter, ICrudRepository<Player, PlayerQueryFilter>>>();
            services.AddTransient<ICrudService<Team, TeamQueryFilter>, CrudService<Team, TeamQueryFilter, ICrudRepository<Team, TeamQueryFilter>>>();
            services.AddTransient<ICrudService<TeamSeason, TeamSeasonQueryFilter>, CrudService<TeamSeason, TeamSeasonQueryFilter, ICrudRepository<TeamSeason, TeamSeasonQueryFilter>>>();
            services.AddTransient<ICrudService<Game, GameQueryFilter>, CrudService<Game, GameQueryFilter, ICrudRepository<Game, GameQueryFilter>>>();
            services.AddTransient<ICrudService<TeamSeasonGame, TeamSeasonGameQueryFilter>, CrudService<TeamSeasonGame, TeamSeasonGameQueryFilter, ICrudRepository<TeamSeasonGame, TeamSeasonGameQueryFilter>>>();
            services.AddTransient<ICrudService<TeamSeasonPlayer, TeamSeasonPlayerQueryFilter>, CrudService<TeamSeasonPlayer, TeamSeasonPlayerQueryFilter, ICrudRepository<TeamSeasonPlayer, TeamSeasonPlayerQueryFilter>>>();
            services.AddTransient<ICrudService<PlayerStat, PlayerStatQueryFilter>, CrudService<PlayerStat, PlayerStatQueryFilter, ICrudRepository<PlayerStat, PlayerStatQueryFilter>>>();
            services.AddTransient<ICrudService<StatType, StatTypeQueryFilter>, CrudService<StatType, StatTypeQueryFilter, ICrudRepository<StatType, StatTypeQueryFilter>>>();

            return services;
        }
    }
}
