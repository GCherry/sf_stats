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
    public class LogRepository : ILogRepository
    {
        private readonly SFStatDbContext _context;

        public LogRepository(SFStatDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Repository to return data from the log table using the filters provided
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Log</returns>
        public async Task<IEnumerable<Log>> GetAsync(LogQueryFilter filter)
        {
            IQueryable<Log> logs = _context.Log;

            if (!string.IsNullOrEmpty(filter.Level))
            {
                logs = logs.Where(x => x.Level == filter.Level);
            }

            if(filter.StartDate != default)
            {
                logs = logs.Where(x => x.TimeStamp >= filter.StartDate);
            }

            if (filter.EndDate != default)
            {
                logs = logs.Where(x => x.TimeStamp <= filter.EndDate);
            }

            if (filter.Top != null)
            {
                logs = logs.Take(filter.Top.Value);
            }

            return await logs.OrderByDescending(x => x.TimeStamp).ToListAsync();
        }
    }
}
