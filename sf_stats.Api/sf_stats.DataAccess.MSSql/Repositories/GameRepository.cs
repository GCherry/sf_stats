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
    public class GameRepository : IGameRepository
    {
        private readonly SFStatDbContext _context;
        public GameRepository(SFStatDbContext context)
        {
            _context = context;
        }

        public async Task<Game> AddAsync(Game Game)
        {
            var item = await _context.AddAsync(Game);
            return item.Entity;
        }

        public async Task DeleteByIdAsync(int GameId)
        {
            // Need to decide if we want to delete or make inactive?
            var item = await _context.Games.Where(x => x.Id == GameId).FirstOrDefaultAsync();
            _context.Remove(item);
        }

        public async Task<List<Game>> GetAsync(GameQueryFilter filter)
        {
            return await _context.Games
                .Where(x => filter.Id == null || x.Id == filter.Id)
                .Where(x => filter.GameDate == null || x.GameDate == filter.GameDate)
                .Where(x => filter.Home_Score == null || x.Home_Score == filter.Home_Score)
                .Where(x => filter.Away_Score == null || x.Away_Score == filter.Away_Score)
                .OrderBy(x => x.CreatedDate)
                .ToListAsync();
        }

        public async Task<Game> GetAsync(int GameId)
        {
            return await _context.Games.FirstOrDefaultAsync(x => x.Id == GameId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Game> Update(Game Game)
        {
            // Check to make sure item exists first before trying to update it.
            var GameRecord = await _context.Games.FirstOrDefaultAsync(x => x.Id == Game.Id);

            if (GameRecord == null)
            {
                return null;
            }

            var item = _context.Update(Game);
            return item.Entity;
        }
    }
}
