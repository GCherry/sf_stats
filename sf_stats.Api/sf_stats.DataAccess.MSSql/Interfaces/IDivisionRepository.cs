using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface IDivisionRepository
    {
        Task<Division> AddAsync(Division Division);
        Task DeleteByIdAsync(int DivisionId);
        Task<List<Division>> GetAsync(DivisionQueryFilter filter);
        Task<Division> GetAsync(int DivisionId);
        Task SaveChangesAsync();
        Task<Division> Update(Division Division);
    }
}
