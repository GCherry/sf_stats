using sf_stats.Api.Interfaces;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        /// <summary>
        /// Service to return data from the log table using the filters provided
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Log</returns>
        public async Task<IEnumerable<Log>> GetAsync(LogQueryFilter filter)
        {
            return await _logRepository.GetAsync(filter);
        }
    }
}
