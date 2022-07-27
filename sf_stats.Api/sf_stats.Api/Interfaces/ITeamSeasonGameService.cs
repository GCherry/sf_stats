using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface ITeamSeasonGameService
    {
        Task<TeamSeasonGame> AddAsync(TeamSeasonGame TeamSeasonGame);
        Task DeleteByIdAsync(int TeamSeasonGameId);
        Task<List<TeamSeasonGame>> GetAsync(TeamSeasonGameQueryFilter filter);
        Task<TeamSeasonGame> GetAsync(int TeamSeasonGameId);
        Task SaveChangesAsync();
        Task<TeamSeasonGame> Update(TeamSeasonGame TeamSeasonGame);
    }
}
