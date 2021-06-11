using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface ISeasonRepository
    {
        Task<Season> AddAsync(Season season);
        Task DeleteByIdAsync(int seasonId);
        Task<List<Season>> GetAsync(SeasonQueryFilter filter);
        Task<Season> GetAsync(int seasonId);
        Task SaveChangesAsync();
        Season Update(Season season);
    }
}
