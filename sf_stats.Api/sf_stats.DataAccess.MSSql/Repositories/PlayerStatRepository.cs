using Microsoft.EntityFrameworkCore;
using sf_stats.DataAccess.MSSql.Context;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Repositories
{
    public class PlayerStatRepository : ICrudRepository<PlayerStat, PlayerStatQueryFilter>
    {
        private readonly SFStatDbContext _context;
        public PlayerStatRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<PlayerStat> AddAsync(PlayerStat PlayerStat)
        {
            var item = await _context.AddAsync(PlayerStat);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int PlayerStatId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.PlayerStats.Where(x => x.Id == PlayerStatId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<PlayerStat>> GetAsync(PlayerStatQueryFilter filter)
        {
            return await _context.PlayerStats
                .Where(x => filter.TeamSeasonPlayerId == null || filter.TeamSeasonPlayerId == x.TeamSeasonPlayerId)
                .Where(x => filter.GameId == null || filter.GameId == x.GameId)
                .Where(x => filter.StatTypeId == null || filter.StatTypeId == x.StatTypeId)
                .Where(x => filter.Value == null || filter.Value == x.Value)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<PlayerStat> GetAsync(int PlayerStatId)
        {
            return await _context.PlayerStats.FirstOrDefaultAsync(x => x.Id == PlayerStatId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<PlayerStat> Update(PlayerStat PlayerStat)
        {
            // Check to make sure item exists first before trying to update it.
            var PlayerStatRecord = await _context.PlayerStats.FirstOrDefaultAsync(x => x.Id == PlayerStat.Id);

            if (PlayerStatRecord == null)
            {
                return null;
            }

            var item = _context.Update(PlayerStat);
            return item.Entity;
        }
    }
}
