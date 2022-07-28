using sf_stats.Api.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using sf_stats.DataAccess.MSSql.Interfaces;

namespace sf_stats.Api.Services
{
    public class CrudService<Entity, Filter, Repository> : ICrudService<Entity, Filter> where Repository : ICrudRepository<Entity, Filter>
    {
        public Repository _repository;
        public CrudService(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Entity> AddAsync(Entity Division)
        {
            return await _repository.AddAsync(Division);
        }

        public async Task DeleteByIdAsync(int DivisionId)
        {
            await _repository.DeleteByIdAsync(DivisionId);
        }

        public async Task<List<Entity>> GetAsync(Filter filter)
        {
            return await _repository.GetAsync(filter);
        }

        public async Task<Entity> GetAsync(int DivisionId)
        {
            return await _repository.GetAsync(DivisionId);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public async Task<Entity> Update(Entity Division)
        {
            return await _repository.Update(Division);
        }
    }
}
