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
    public class TeamSeasonRepository : ICrudRepository<TeamSeason, TeamSeasonQueryFilter>
    {
        private readonly SFStatDbContext _context;
        public TeamSeasonRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<TeamSeason> AddAsync(TeamSeason TeamSeason)
        {
            var item = await _context.AddAsync(TeamSeason);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int TeamSeasonId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.TeamSeasons.Where(x => x.Id == TeamSeasonId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<TeamSeason>> GetAsync(TeamSeasonQueryFilter filter)
        {
            return await _context.TeamSeasons
                .Where(x => filter.Id == null || filter.Id == x.Id) 
                .Where(x => filter.SeasonId == null || filter.SeasonId == x.SeasonId) 
                .Where(x => filter.TeamId == null || filter.TeamId == x.TeamId) 
                .OrderBy(x => x.SeasonId)
                .ToListAsync();
        }

        public async Task<TeamSeason> GetAsync(int TeamSeasonId)
        {
            return await _context.TeamSeasons.FirstOrDefaultAsync(x => x.Id == TeamSeasonId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TeamSeason> Update(TeamSeason TeamSeason)
        {
            // Check to make sure item exists first before trying to update it.
            var TeamSeasonRecord = await _context.TeamSeasons.FirstOrDefaultAsync(x => x.Id == TeamSeason.Id);

            if (TeamSeasonRecord == null)
            {
                return null;
            }

            var item = _context.Update(TeamSeason);
            return item.Entity;
        }
    }
}
