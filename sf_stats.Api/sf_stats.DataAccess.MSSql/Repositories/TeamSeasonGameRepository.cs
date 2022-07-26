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
    public class TeamSeasonGameRepository : ITeamSeasonGameRepository
    {
        private readonly SFStatDbContext _context;
        public TeamSeasonGameRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<TeamSeasonGame> AddAsync(TeamSeasonGame TeamSeasonGame)
        {
            var item = await _context.AddAsync(TeamSeasonGame);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int TeamSeasonGameId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.TeamSeasonGames.Where(x => x.Id == TeamSeasonGameId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<TeamSeasonGame>> GetAsync(TeamSeasonGameQueryFilter filter)
        {
            return await _context.TeamSeasonGames
                .Where(x => filter.Id == null || filter.Id == x.Id) 
                .Where(x => filter.GameId == null || filter.GameId == x.GameId) 
                .Where(x => filter.TeamSeasonId == null || filter.TeamSeasonId == x.TeamSeasonId) 
                .Where(x => filter.IsHomeTeam == null || filter.IsHomeTeam == x.IsHomeTeam) 
                .OrderBy(x => x.GameId)
                .ToListAsync();
        }

        public async Task<TeamSeasonGame> GetAsync(int TeamSeasonGameId)
        {
            return await _context.TeamSeasonGames.FirstOrDefaultAsync(x => x.Id == TeamSeasonGameId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TeamSeasonGame> Update(TeamSeasonGame TeamSeasonGame)
        {
            // Check to make sure item exists first before trying to update it.
            var TeamSeasonGameRecord = await _context.TeamSeasonGames.FirstOrDefaultAsync(x => x.Id == TeamSeasonGame.Id);

            if (TeamSeasonGameRecord == null)
            {
                return null;
            }

            var item = _context.Update(TeamSeasonGame);
            return item.Entity;
        }
    }
}
