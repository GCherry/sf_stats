using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> AddAsync(Game Game);
        Task DeleteByIdAsync(int GameId);
        Task<List<Game>> GetAsync(GameQueryFilter filter);
        Task<Game> GetAsync(int GameId);
        Task SaveChangesAsync();
        Task<Game> Update(Game Game);
    }
}
