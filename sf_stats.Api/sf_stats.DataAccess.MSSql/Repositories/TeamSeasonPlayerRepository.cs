using Microsoft.EntityFrameworkCore;
using sf_stats.DataAccess.MSSql.Context;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Repositories
{
    public class TeamSeasonPlayerRepository : ITeamSeasonPlayerRepository
    {
        private readonly SFStatDbContext _context;
        public TeamSeasonPlayerRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<TeamSeasonPlayer> AddAsync(TeamSeasonPlayer TeamSeasonPlayer)
        {
            var item = await _context.AddAsync(TeamSeasonPlayer);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int TeamSeasonPlayerId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.TeamSeasonPlayers.Where(x => x.Id == TeamSeasonPlayerId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<TeamSeasonPlayer>> GetAsync(TeamSeasonPlayerQueryFilter filter)
        {
            return await _context.TeamSeasonPlayers
                .Where(x => filter.Id == null || filter.Id == x.Id) 
                .Where(x => filter.PlayerId == null || filter.PlayerId == x.PlayerId) 
                .Where(x => filter.TeamSeasonId == null || filter.TeamSeasonId == x.TeamSeasonId)
                .OrderBy(x => x.PlayerId)
                .ToListAsync();
        }

        public async Task<TeamSeasonPlayer> GetAsync(int TeamSeasonPlayerId)
        {
            return await _context.TeamSeasonPlayers.FirstOrDefaultAsync(x => x.Id == TeamSeasonPlayerId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TeamSeasonPlayer> Update(TeamSeasonPlayer TeamSeasonPlayer)
        {
            // Check to make sure item exists first before trying to update it.
            var TeamSeasonPlayerRecord = await _context.TeamSeasonPlayers.FirstOrDefaultAsync(x => x.Id == TeamSeasonPlayer.Id);

            if (TeamSeasonPlayerRecord == null)
            {
                return null;
            }

            var item = _context.Update(TeamSeasonPlayer);
            return item.Entity;
        }
    }
}
