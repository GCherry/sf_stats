using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _TeamRepository;

        public TeamService(ITeamRepository TeamRepository)
        {
            _TeamRepository = TeamRepository;
        }

        public async Task<Team> AddAsync(Team Team)
        {
            return await _TeamRepository.AddAsync(Team);
        }

        public async Task DeleteByIdAsync(int TeamId)
        {
            await _TeamRepository.DeleteByIdAsync(TeamId);
        }

        public async Task<List<Team>> GetAsync(TeamQueryFilter filter)
        {
            return await _TeamRepository.GetAsync(filter);
        }

        public async Task<Team> GetAsync(int TeamId)
        {
            return await _TeamRepository.GetAsync(TeamId);
        }

        public async Task SaveChangesAsync()
        {
            await _TeamRepository.SaveChangesAsync();
        }

        public async Task<Team> Update(Team Team)
        {
            return await _TeamRepository.Update(Team);
        }
    }
}
