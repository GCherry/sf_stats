using Microsoft.EntityFrameworkCore;
using sf_stats.DataAccess.MSSql.Context;
using sf_stats.DataAccess.MSSql.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Repositories
{
    public class TeamRepository : ICrudRepository<Team, TeamQueryFilter>
    {
        private readonly SFStatDbContext _context;
        public TeamRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<Team> AddAsync(Team Team)
        {
            var item = await _context.AddAsync(Team);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int TeamId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.Teams.Where(x => x.Id == TeamId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<Team>> GetAsync(TeamQueryFilter filter)
        {
            return await _context.Teams
                .Where(x => string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name))
                .Where(x => string.IsNullOrEmpty(filter.NameAbbreviation) || x.NameAbbreviation.Contains(filter.NameAbbreviation))
                .Where(x => x.IsActive == filter.IsActive)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Team> GetAsync(int TeamId)
        {
            return await _context.Teams.FirstOrDefaultAsync(x => x.Id == TeamId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Team> Update(Team Team)
        {
            // Check to make sure item exists first before trying to update it.
            var TeamRecord = await _context.Teams.FirstOrDefaultAsync(x => x.Id == Team.Id);

            if (TeamRecord == null)
            {
                return null;
            }

            var item = _context.Update(Team);
            return item.Entity;
        }
    }
}
