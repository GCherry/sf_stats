using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface ITeamSeasonPlayerService
    {
        Task<TeamSeasonPlayer> AddAsync(TeamSeasonPlayer TeamSeasoPlayer);
        Task DeleteByIdAsync(int TeamSeasonPlayerId);
        Task<List<TeamSeasonPlayer>> GetAsync(TeamSeasonPlayerQueryFilter filter);
        Task<TeamSeasonPlayer> GetAsync(int TeamSeasonPlayerId);
        Task SaveChangesAsync();
        Task<TeamSeasonPlayer> Update(TeamSeasonPlayer TeamSeasonPlayer);
    }
}
