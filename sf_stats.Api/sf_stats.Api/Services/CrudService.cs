using sf_stats.Api.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using sf_stats.DataAccess.MSSql.Interfaces;

namespace sf_stats.Api.Services
{
    public class CrudService<TEntity, TFilter, TRepository> : ICrudService<TEntity, TFilter> where TRepository : ICrudRepository<TEntity, TFilter>
    {
        public TRepository _TRepository;
        public CrudService(TRepository TRepository)
        {
            _TRepository = TRepository;
        }

        public async Task<TEntity> AddAsync(TEntity TEntity)
        {
            return await _TRepository.AddAsync(TEntity);
        }

        public async Task DeleteByIdAsync(int Id)
        {
            await _TRepository.DeleteByIdAsync(Id);
        }

        public async Task<List<TEntity>> GetAsync(TFilter TFilter)
        {
            return await _TRepository.GetAsync(TFilter);
        }

        public async Task<TEntity> GetAsync(int Id)
        {
            return await _TRepository.GetAsync(Id);
        }

        public async Task SaveChangesAsync()
        {
            await _TRepository.SaveChangesAsync();
        }

        public async Task<TEntity> Update(TEntity TEntity)
        {
            return await _TRepository.Update(TEntity);
        }
    }
}
