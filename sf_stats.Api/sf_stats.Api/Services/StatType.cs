using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class StatTypeService : IStatTypeService
    {
        private readonly IStatTypeRepository _StatTypeRepository;

        public StatTypeService(IStatTypeRepository StatTypeRepository)
        {
            _StatTypeRepository = StatTypeRepository;
        }

        public async Task<StatType> AddAsync(StatType StatType)
        {
            return await _StatTypeRepository.AddAsync(StatType);
        }

        public async Task DeleteByIdAsync(int StatTypeId)
        {
            await _StatTypeRepository.DeleteByIdAsync(StatTypeId);
        }

        public async Task<List<StatType>> GetAsync(StatTypeQueryFilter filter)
        {
            return await _StatTypeRepository.GetAsync(filter);
        }

        public async Task<StatType> GetAsync(int StatTypeId)
        {
            return await _StatTypeRepository.GetAsync(StatTypeId);
        }

        public async Task SaveChangesAsync()
        {
            await _StatTypeRepository.SaveChangesAsync();
        }

        public async Task<StatType> Update(StatType StatType)
        {
            return await _StatTypeRepository.Update(StatType);
        }
    }
}
