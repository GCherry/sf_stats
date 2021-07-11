using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _PlayerRepository;

        public PlayerService(IPlayerRepository PlayerRepository)
        {
            _PlayerRepository = PlayerRepository;
        }

        public async Task<Player> AddAsync(Player Player)
        {
            return await _PlayerRepository.AddAsync(Player);
        }

        public async Task DeleteByIdAsync(int PlayerId)
        {
            await _PlayerRepository.DeleteByIdAsync(PlayerId);
        }

        public async Task<List<Player>> GetAsync(PlayerQueryFilter filter)
        {
            return await _PlayerRepository.GetAsync(filter);
        }

        public async Task<Player> GetAsync(int PlayerId)
        {
            return await _PlayerRepository.GetAsync(PlayerId);
        }

        public async Task SaveChangesAsync()
        {
            await _PlayerRepository.SaveChangesAsync();
        }

        public async Task<Player> Update(Player Player)
        {
            return await _PlayerRepository.Update(Player);
        }
    }
}
