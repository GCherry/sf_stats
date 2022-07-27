using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface IPlayerStatRepository
    {
        Task<PlayerStat> AddAsync(PlayerStat PlayerStat);
        Task DeleteByIdAsync(int PlayerStatId);
        Task<List<PlayerStat>> GetAsync(PlayerStatQueryFilter filter);
        Task<PlayerStat> GetAsync(int PlayerStatId);
        Task SaveChangesAsync();
        Task<PlayerStat> Update(PlayerStat PlayerStat);
    }
}
