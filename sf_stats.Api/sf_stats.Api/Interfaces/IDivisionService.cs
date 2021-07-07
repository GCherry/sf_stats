using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface IDivisionService
    {
        Task<Division> AddAsync(Division division);
        Task DeleteByIdAsync(int divisionId);
        Task<List<Division>> GetAsync(DivisionQueryFilter filter);
        Task<Division> GetAsync(int divisionId);
        Task SaveChangesAsync();
        Task<Division> Update(Division division);
    }
}