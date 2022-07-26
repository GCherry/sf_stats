using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class TeamSeasonGameService : ITeamSeasonGameService
    {
        private readonly ITeamSeasonGameRepository _TeamSeasonGameRepository;

        public TeamSeasonGameService(ITeamSeasonGameRepository TeamSeasonGameRepository)
        {
            _TeamSeasonGameRepository = TeamSeasonGameRepository;
        }

        public async Task<TeamSeasonGame> AddAsync(TeamSeasonGame TeamSeasonGame)
        {
            return await _TeamSeasonGameRepository.AddAsync(TeamSeasonGame);
        }

        public async Task DeleteByIdAsync(int TeamSeasonGameId)
        {
            await _TeamSeasonGameRepository.DeleteByIdAsync(TeamSeasonGameId);
        }

        public async Task<List<TeamSeasonGame>> GetAsync(TeamSeasonGameQueryFilter filter)
        {
            return await _TeamSeasonGameRepository.GetAsync(filter);
        }

        public async Task<TeamSeasonGame> GetAsync(int TeamSeasonGameId)
        {
            return await _TeamSeasonGameRepository.GetAsync(TeamSeasonGameId);
        }

        public async Task SaveChangesAsync()
        {
            await _TeamSeasonGameRepository.SaveChangesAsync();
        }

        public async Task<TeamSeasonGame> Update(TeamSeasonGame TeamSeasonGame)
        {
            return await _TeamSeasonGameRepository.Update(TeamSeasonGame);
        }
    }
}
