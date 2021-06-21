using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sf_stats.Domain.Entities;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class TeamSeasonPlayerEntityConfiguration : IEntityTypeConfiguration<TeamSeasonPlayer>
    {
        public void Configure(EntityTypeBuilder<TeamSeasonPlayer> builder)
        {
            builder.HasOne(x => x.TeamSeason).WithMany(x => x.TeamSeasonPlayers);
            builder.HasOne(x => x.Player).WithMany(x => x.TeamSeasonPlayers);
            builder.HasMany(x => x.PlayerStats).WithOne(x => x.TeamSeasonPlayer);

            builder.Property(x => x.PlayerId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.TeamSeasonId)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("TeamSeasonPlayer");
        }
    }
}
