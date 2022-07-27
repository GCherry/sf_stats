using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface ITeamSeasonPlayerRepository
    {
        Task<TeamSeasonPlayer> AddAsync(TeamSeasonPlayer TeamSeasonPlayer);
        Task DeleteByIdAsync(int TeamSeasonPlayerId);
        Task<List<TeamSeasonPlayer>> GetAsync(TeamSeasonPlayerQueryFilter filter);
        Task<TeamSeasonPlayer> GetAsync(int TeamSeasonPlayerId);
        Task SaveChangesAsync();
        Task<TeamSeasonPlayer> Update(TeamSeasonPlayer TeamSeasonPlayer);
    }
}
