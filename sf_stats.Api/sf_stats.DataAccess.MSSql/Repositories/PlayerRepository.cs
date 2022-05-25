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
    public class PlayerRepository : IPlayerRepository
    {
        private readonly SFStatDbContext _context;
        public PlayerRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<Player> AddAsync(Player Player)
        {
            var item = await _context.AddAsync(Player);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int PlayerId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.Players.Where(x => x.Id == PlayerId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<Player>> GetAsync(PlayerQueryFilter filter)
        {
            return await _context.Players
                .Where(x => filter.Id == null || filter.Id == x.Id)
                .Where(x => string.IsNullOrEmpty(filter.FirstName) || x.FirstName.Contains(filter.FirstName))
                .Where(x => string.IsNullOrEmpty(filter.MiddleName) || x.MiddleName.Contains(filter.MiddleName))
                .Where(x => string.IsNullOrEmpty(filter.LastName) || x.LastName.Contains(filter.LastName))
                .Where(x => filter.DateOfBirth == null || x.DateOfBirth == filter.DateOfBirth)
                .Where(x => filter.Height == null  || x.Height == filter.Height)
                .Where(x => filter.Weight == null  || x.Weight == filter.Weight)
                .OrderBy(x => x.LastName)
                .ToListAsync();
        }

        public async Task<Player> GetAsync(int PlayerId)
        {
            return await _context.Players.FirstOrDefaultAsync(x => x.Id == PlayerId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Player> Update(Player Player)
        {
            // Check to make sure item exists first before trying to update it.
            var PlayerRecord = await _context.Players.FirstOrDefaultAsync(x => x.Id == Player.Id);

            if (PlayerRecord == null)
            {
                return null;
            }

            var item = _context.Update(Player);
            return item.Entity;
        }
    }
}
