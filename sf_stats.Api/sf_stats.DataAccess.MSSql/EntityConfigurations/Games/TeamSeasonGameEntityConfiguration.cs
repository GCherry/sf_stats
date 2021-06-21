using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sf_stats.Domain.Entities;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class TeamSeasonGameEntityConfiguration : IEntityTypeConfiguration<TeamSeasonGame>
    {
        public void Configure(EntityTypeBuilder<TeamSeasonGame> builder)
        {
            builder.HasOne(x => x.Game).WithMany(x => x.TeamSeasonGames);
            builder.HasOne(x => x.TeamSeason).WithMany(x => x.TeamSeasonGames);

            builder.Property(x => x.GameId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.TeamSeasonId)
                .HasColumnType("int");

            builder.Property(x => x.IsHomeTeam)
                .HasColumnType("bit");

            builder.ToTable("TeamSeasonGame");
        }
    }
}
