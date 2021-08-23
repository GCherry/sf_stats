using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team> AddAsync(Team Team);
        Task DeleteByIdAsync(int TeamId);
        Task<List<Team>> GetAsync(TeamQueryFilter filter);
        Task<Team> GetAsync(int TeamId);
        Task SaveChangesAsync();
        Task<Team> Update(Team Team);
    }
}
