using Microsoft.EntityFrameworkCore;
using sf_stats.DataAccess.MSSql.Context;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Repositories
{
    public class StatTypeRepository : ICrudRepository<StatType, StatTypeQueryFilter>
    {
        private readonly SFStatDbContext _context;
        public StatTypeRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<StatType> AddAsync(StatType StatType)
        {
            var item = await _context.AddAsync(StatType);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int StatTypeId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.StatTypes.Where(x => x.Id == StatTypeId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<StatType>> GetAsync(StatTypeQueryFilter filter)
        {
            return await _context.StatTypes
                .Where(x => filter.Id == null || filter.Id == x.Id)
                .Where(x => string.IsNullOrEmpty(filter.DisplayName) || x.DisplayName.Contains(filter.DisplayName))
                .Where(x => string.IsNullOrEmpty(filter.Code) || x.Code.Contains(filter.Code))
                .OrderBy(x => x.DisplayName)
                .ToListAsync();
        }

        public async Task<StatType> GetAsync(int StatTypeId)
        {
            return await _context.StatTypes.FirstOrDefaultAsync(x => x.Id == StatTypeId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<StatType> Update(StatType StatType)
        {
            // Check to make sure item exists first before trying to update it.
            var StatTypeRecord = await _context.StatTypes.FirstOrDefaultAsync(x => x.Id == StatType.Id);

            if (StatTypeRecord == null)
            {
                return null;
            }

            var item = _context.Update(StatType);
            return item.Entity;
        }
    }
}
