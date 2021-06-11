using Microsoft.EntityFrameworkCore;
using sf_stats.DataAccess.MSSql.EntityConfigurations;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public override int SaveChanges()
        {
            UpdateCreateDate();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateCreateDate();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateCreateDate()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is DbEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((DbEntity)entityEntry.Entity).CreatedDate = DateTimeOffset.Now;
                }

                if (entityEntry.State == EntityState.Added)
                {
                    ((DbEntity)entityEntry.Entity).LastModifiedDate = DateTimeOffset.Now;
                }
            }
        }
    }
}
