using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface IGameService
    {
        Task<Game> AddAsync(Game Game);
        Task DeleteByIdAsync(int GameId);
        Task<List<Game>> GetAsync(GameQueryFilter filter);
        Task<Game> GetAsync(int GameId);
        Task SaveChangesAsync();
        Task<Game> Update(Game Game);
    }
}
