using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _GameRepository;

        public GameService(IGameRepository GameRepository)
        {
            _GameRepository = GameRepository;
        }

        public async Task<Game> AddAsync(Game Game)
        {
            return await _GameRepository.AddAsync(Game);
        }

        public async Task DeleteByIdAsync(int GameId)
        {
            await _GameRepository.DeleteByIdAsync(GameId);
        }

        public async Task<List<Game>> GetAsync(GameQueryFilter filter)
        {
            return await _GameRepository.GetAsync(filter);
        }

        public async Task<Game> GetAsync(int GameId)
        {
            return await _GameRepository.GetAsync(GameId);
        }

        public async Task SaveChangesAsync()
        {
            await _GameRepository.SaveChangesAsync();
        }

        public async Task<Game> Update(Game Game)
        {
            return await _GameRepository.Update(Game);
        }
    }
}
