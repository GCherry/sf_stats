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
    public class DivisionRepository : IDivisionRepository
    {
        private readonly SFStatDbContext _context;
        public DivisionRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<Division> AddAsync(Division Division)
        {
            var item = await _context.AddAsync(Division);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int DivisionId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.Divisions.Where(x => x.Id == DivisionId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<Division>> GetAsync(DivisionQueryFilter filter)
        {
            return await _context.Divisions
                .Where(x => filter.Id == null || filter.Id == x.Id)
                .Where(x => string.IsNullOrEmpty(filter.Name) || x.DisplayName.Contains(filter.Name))
                .Where(x => string.IsNullOrEmpty(filter.Code) || x.Code.Contains(filter.Code))
                .OrderBy(x => x.DisplayName)
                .ToListAsync();
        }

        public async Task<Division> GetAsync(int DivisionId)
        {
            return await _context.Divisions.FirstOrDefaultAsync(x => x.Id == DivisionId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Division> Update(Division Division)
        {
            // Check to make sure item exists first before trying to update it.
            var DivisionRecord = await _context.Divisions.FirstOrDefaultAsync(x => x.Id == Division.Id);

            if (DivisionRecord == null)
            {
                return null;
            }
            else
            {
                _context.Entry(DivisionRecord).State = EntityState.Detached;
            }

            var item = _context.Update(Division);
            return item.Entity;
        }
    }
}
