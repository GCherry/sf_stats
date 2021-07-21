using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface ITeamService
    {
        Task<Team> AddAsync(Team Team);
        Task DeleteByIdAsync(int TeamId);
        Task<List<Team>> GetAsync(TeamQueryFilter filter);
        Task<Team> GetAsync(int TeamId);
        Task SaveChangesAsync();
        Task<Team> Update(Team Team);
    }
}
