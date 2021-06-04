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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new LogEntityConfiguration())
                        .ApplyConfiguration(new SeasonEntityConfiguration())
                        .ApplyConfiguration(new DivisionEntityConfiguration())
                        .ApplyConfiguration(new TeamEntityConfiguration())
                        .ApplyConfiguration(new PlayerEntityConfiguration());
        }
    }
}
