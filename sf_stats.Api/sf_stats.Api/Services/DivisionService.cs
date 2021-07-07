using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class DivisionService : IDivisionService
    {
        private readonly IDivisionRepository _DivisionRepository;

        public DivisionService(IDivisionRepository DivisionRepository)
        {
            _DivisionRepository = DivisionRepository;
        }

        public async Task<Division> AddAsync(Division Division)
        {
            return await _DivisionRepository.AddAsync(Division);
        }

        public async Task DeleteByIdAsync(int DivisionId)
        {
            await _DivisionRepository.DeleteByIdAsync(DivisionId);
        }

        public async Task<List<Division>> GetAsync(DivisionQueryFilter filter)
        {
            return await _DivisionRepository.GetAsync(filter);
        }

        public async Task<Division> GetAsync(int DivisionId)
        {
            return await _DivisionRepository.GetAsync(DivisionId);
        }

        public async Task SaveChangesAsync()
        {
            await _DivisionRepository.SaveChangesAsync();
        }

        public async Task<Division> Update(Division Division)
        {
            return await _DivisionRepository.Update(Division);
        }
    }
}
