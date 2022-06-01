using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface ITeamSeasonRepository
    {
        Task<TeamSeason> AddAsync(TeamSeason TeamSeason);
        Task DeleteByIdAsync(int TeamSeasonId);
        Task<List<TeamSeason>> GetAsync(TeamSeasonQueryFilter filter);
        Task<TeamSeason> GetAsync(int TeamSeasonId);
        Task SaveChangesAsync();
        Task<TeamSeason> Update(TeamSeason TeamSeason);
    }
}
