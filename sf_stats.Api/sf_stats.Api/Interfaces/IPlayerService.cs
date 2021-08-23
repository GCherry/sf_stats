using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface IPlayerService
    {
        Task<Player> AddAsync(Player Player);
        Task DeleteByIdAsync(int PlayerId);
        Task<List<Player>> GetAsync(PlayerQueryFilter filter);
        Task<Player> GetAsync(int PlayerId);
        Task SaveChangesAsync();
        Task<Player> Update(Player Player);
    }
}