using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface ISeasonService
    {
        Task<Season> AddAsync(Season season);
        Task DeleteByIdAsync(int seasonId);
        Task<List<Season>> GetAsync(SeasonQueryFilter filter);
        Task<Season> GetAsync(int seasonId);
        Task SaveChangesAsync();
        Task<Season> Update(Season season);
    }
}
