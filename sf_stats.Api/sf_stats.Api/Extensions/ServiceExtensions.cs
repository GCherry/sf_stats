using Microsoft.Extensions.DependencyInjection;
using sf_stats.Api.Interfaces;
using sf_stats.Api.Services;

namespace sf_stats.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<ISeasonService, SeasonService>();
            services.AddTransient<IDivisionService, DivisionService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITeamSeasonService, TeamSeasonService>();

            return services;
        }
    }
}
