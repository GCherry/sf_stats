using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Interfaces
{
    public interface ICrudRepository<TEntity, TFilter>
    {
        Task<TEntity> AddAsync(TEntity TEntity);
        Task DeleteByIdAsync(int Id);
        Task<List<TEntity>> GetAsync(TFilter TFilter);
        Task<TEntity> GetAsync(int Id);
        Task SaveChangesAsync();
        Task<TEntity> Update(TEntity TEntity);
    }
}
