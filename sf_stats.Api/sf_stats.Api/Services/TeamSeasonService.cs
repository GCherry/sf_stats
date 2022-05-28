using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class TeamSeasonService : ITeamSeasonService
    {
        private readonly ITeamSeasonRepository _TeamSeasonRepository;

        public TeamSeasonService(ITeamSeasonRepository TeamSeasonRepository)
        {
            _TeamSeasonRepository = TeamSeasonRepository;
        }

        public async Task<TeamSeason> AddAsync(TeamSeason TeamSeason)
        {
            return await _TeamSeasonRepository.AddAsync(TeamSeason);
        }

        public async Task DeleteByIdAsync(int TeamSeasonId)
        {
            await _TeamSeasonRepository.DeleteByIdAsync(TeamSeasonId);
        }

        public async Task<List<TeamSeason>> GetAsync(TeamSeasonQueryFilter filter)
        {
            return await _TeamSeasonRepository.GetAsync(filter);
        }

        public async Task<TeamSeason> GetAsync(int TeamSeasonId)
        {
            return await _TeamSeasonRepository.GetAsync(TeamSeasonId);
        }

        public async Task SaveChangesAsync()
        {
            await _TeamSeasonRepository.SaveChangesAsync();
        }

        public async Task<TeamSeason> Update(TeamSeason TeamSeason)
        {
            return await _TeamSeasonRepository.Update(TeamSeason);
        }
    }
}
