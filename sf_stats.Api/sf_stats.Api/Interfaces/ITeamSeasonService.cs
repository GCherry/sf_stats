using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface ITeamSeasonService
    {
        Task<TeamSeason> AddAsync(TeamSeason TeamSeason);
        Task DeleteByIdAsync(int TeamSeasonId);
        Task<List<TeamSeason>> GetAsync(TeamSeasonQueryFilter filter);
        Task<TeamSeason> GetAsync(int TeamSeasonId);
        Task SaveChangesAsync();
        Task<TeamSeason> Update(TeamSeason TeamSeason);
    }
}
