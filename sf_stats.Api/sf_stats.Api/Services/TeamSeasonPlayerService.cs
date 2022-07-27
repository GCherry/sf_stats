using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class TeamSeasonPlayerService : ITeamSeasonPlayerService
    {
        private readonly ITeamSeasonPlayerRepository _TeamSeasonPlayerRepository;

        public TeamSeasonPlayerService(ITeamSeasonPlayerRepository TeamSeasonPlayerRepository)
        {
            _TeamSeasonPlayerRepository = TeamSeasonPlayerRepository;
        }

        public async Task<TeamSeasonPlayer> AddAsync(TeamSeasonPlayer TeamSeasonPlayer)
        {
            return await _TeamSeasonPlayerRepository.AddAsync(TeamSeasonPlayer);
        }

        public async Task DeleteByIdAsync(int TeamSeasonPlayerId)
        {
            await _TeamSeasonPlayerRepository.DeleteByIdAsync(TeamSeasonPlayerId);
        }

        public async Task<List<TeamSeasonPlayer>> GetAsync(TeamSeasonPlayerQueryFilter filter)
        {
            return await _TeamSeasonPlayerRepository.GetAsync(filter);
        }

        public async Task<TeamSeasonPlayer> GetAsync(int TeamSeasonPlayerId)
        {
            return await _TeamSeasonPlayerRepository.GetAsync(TeamSeasonPlayerId);
        }

        public async Task SaveChangesAsync()
        {
            await _TeamSeasonPlayerRepository.SaveChangesAsync();
        }

        public async Task<TeamSeasonPlayer> Update(TeamSeasonPlayer TeamSeasonPlayer)
        {
            return await _TeamSeasonPlayerRepository.Update(TeamSeasonPlayer);
        }
    }
}
