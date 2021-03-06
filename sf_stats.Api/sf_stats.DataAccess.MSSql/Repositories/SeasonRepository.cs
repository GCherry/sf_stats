using Microsoft.EntityFrameworkCore;
using sf_stats.DataAccess.MSSql.Context;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Repositories
{
    public class SeasonRepository : ICrudRepository<Season, SeasonQueryFilter>
    {
        private readonly SFStatDbContext _context;
        public SeasonRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<Season> AddAsync(Season season)
        {
            var item = await _context.AddAsync(season);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int seasonId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.Seasons.Where(x => x.Id == seasonId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<Season>> GetAsync(SeasonQueryFilter filter)
        {
            return await _context.Seasons
                .Where(x => filter.Id == null || filter.Id == x.Id)
                .Where(x => string.IsNullOrEmpty(filter.Name) || x.DisplayName.Contains(filter.Name))
                .Where(x => string.IsNullOrEmpty(filter.Code) || x.Code.Contains(filter.Code))
                .Where(CheckDates(filter.StartDate, filter.EndDate))
                .OrderBy(x => x.DisplayName)
                .ToListAsync();
        }

        public async Task<Season> GetAsync(int seasonId)
        {
            return await _context.Seasons.FirstOrDefaultAsync(x => x.Id == seasonId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Season> Update(Season season)
        {
            // Check to make sure item exists first before trying to update it.
            var seasonRecord = await _context.Seasons.FirstOrDefaultAsync(x => x.Id == season.Id);

            if (seasonRecord == null)
            {
                return null;
            }

            var item = _context.Update(season);
            return item.Entity;
        }

        private static Expression<Func<Season, bool>> CheckDates(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            bool bothDatesNull = !startDate.HasValue && !endDate.HasValue;
            bool justStartDate = startDate.HasValue && !endDate.HasValue;
            bool justEndDate = !startDate.HasValue && !endDate.HasValue;

            if (bothDatesNull)
            {
                return _ => true;
            }

            // Get everything after the start date
            if (justStartDate)
            {
                return Season => Season.StartDate >= startDate.Value.Date;
            }

            if (justEndDate)
            {
                return Season => Season.EndDate <= endDate.Value.Date;
            }

            return Season => Season.StartDate >= startDate && Season.EndDate <= endDate;
        }
    }
}
