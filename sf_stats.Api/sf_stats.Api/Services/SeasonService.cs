using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;

        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<Season> AddAsync(Season season)
        {
            return await _seasonRepository.AddAsync(season);
        }

        public async Task DeleteByIdAsync(int seasonId)
        {
            await _seasonRepository.DeleteByIdAsync(seasonId);
        }

        public async Task<List<Season>> GetAsync(SeasonQueryFilter filter)
        {
            return await _seasonRepository.GetAsync(filter);
        }

        public async Task<Season> GetAsync(int seasonId)
        {
            return await _seasonRepository.GetAsync(seasonId);
        }

        public async Task SaveChangesAsync()
        {
            await _seasonRepository.SaveChangesAsync();
        }

        public Season Update(Season season)
        {
            return _seasonRepository.Update(season);
        }
    }
}
