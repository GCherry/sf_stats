using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface ICrudRepository<Entity, Filter>
    {
        Task<Entity> AddAsync(Entity Division);
        Task DeleteByIdAsync(int DivisionId);
        Task<List<Entity>> GetAsync(Filter filter);
        Task<Entity> GetAsync(int DivisionId);
        Task SaveChangesAsync();
        Task<Entity> Update(Entity Division);
    }
}
