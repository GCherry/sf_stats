using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Interfaces
{
    public interface IGameService : ICrudService<Game>
    {
        Task<List<Game>> GetAsync(GameQueryFilter filter);
    }
}
