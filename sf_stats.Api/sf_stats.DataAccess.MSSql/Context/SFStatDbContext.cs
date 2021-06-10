using Microsoft.EntityFrameworkCore;
using sf_stats.DataAccess.MSSql.EntityConfigurations;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.Context
{
    public class SFStatDbContext : DbContext
    {
        public SFStatDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Log> Log { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<StatType> StatTypes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerStat> PlayerStats { get; set; }
        public DbSet<TeamSeason> TeamSeasons { get; set; }
        public DbSet<TeamSeasonPlayer> TeamSeasonPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new LogEntityConfiguration())
                        .ApplyConfiguration(new SeasonEntityConfiguration())
                        .ApplyConfiguration(new DivisionEntityConfiguration())
                        .ApplyConfiguration(new TeamEntityConfiguration())
                        .ApplyConfiguration(new StatTypeEntityConfiguration())
                        .ApplyConfiguration(new PlayerEntityConfiguration())
                        .ApplyConfiguration(new GameEntityConfiguration())
                        .ApplyConfiguration(new PlayerStatEntityConfiguration())
                        .ApplyConfiguration(new TeamSeasonEntityConfiguration())
                        .ApplyConfiguration(new TeamSeasonPlayerEntityConfiguration());
        }
    }
}
