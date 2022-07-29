using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface ICrudService<TEntity, TFilter>
    {
        Task<TEntity> GetAsync(int id);
        Task<TEntity> AddAsync(TEntity TEntity);
        Task SaveChangesAsync();
        Task<TEntity> Update(TEntity TEntity);
        Task DeleteByIdAsync(int TEntityId);
        Task<List<TEntity>> GetAsync(TFilter TFilter);
    }
}