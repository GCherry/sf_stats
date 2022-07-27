using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class PlayerStatService : IPlayerStatService
    {
        private readonly IPlayerStatRepository _PlayerStatRepository;

        public PlayerStatService(IPlayerStatRepository PlayerStatRepository)
        {
            _PlayerStatRepository = PlayerStatRepository;
        }

        public async Task<PlayerStat> AddAsync(PlayerStat PlayerStat)
        {
            return await _PlayerStatRepository.AddAsync(PlayerStat);
        }

        public async Task DeleteByIdAsync(int PlayerStatId)
        {
            await _PlayerStatRepository.DeleteByIdAsync(PlayerStatId);
        }

        public async Task<List<PlayerStat>> GetAsync(PlayerStatQueryFilter filter)
        {
            return await _PlayerStatRepository.GetAsync(filter);
        }

        public async Task<PlayerStat> GetAsync(int PlayerStatId)
        {
            return await _PlayerStatRepository.GetAsync(PlayerStatId);
        }

        public async Task SaveChangesAsync()
        {
            await _PlayerStatRepository.SaveChangesAsync();
        }

        public async Task<PlayerStat> Update(PlayerStat PlayerStat)
        {
            return await _PlayerStatRepository.Update(PlayerStat);
        }
    }
}
