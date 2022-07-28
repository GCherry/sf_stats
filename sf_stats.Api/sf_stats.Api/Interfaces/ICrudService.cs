using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface ICrudService<Entity, Filter>
    {
        Task<Entity> GetAsync(int id);
        Task<Entity> AddAsync(Entity entity);
        Task SaveChangesAsync();
        Task<Entity> Update(Entity division);
        Task DeleteByIdAsync(int divisionId);
        Task<List<Entity>> GetAsync(Filter filter);
    }
}