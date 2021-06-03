using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface ILogService
    {
        Task<IEnumerable<Log>> GetAsync(LogQueryFilter filter);
    }
}
