using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface IStatTypeRepository
    {
        Task<StatType> AddAsync(StatType StatType);
        Task DeleteByIdAsync(int StatTypeId);
        Task<List<StatType>> GetAsync(StatTypeQueryFilter filter);
        Task<StatType> GetAsync(int StatTypeId);
        Task SaveChangesAsync();
        Task<StatType> Update(StatType StatType);
    }
}
