using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sf_stats.Domain.Entities;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class TeamSeasonEntityConfiguration : IEntityTypeConfiguration<TeamSeason>
    {
        public void Configure(EntityTypeBuilder<TeamSeason> builder)
        {
            builder.HasOne(x => x.Team).WithMany(x => x.TeamSeasons);
            builder.HasOne(x => x.Season).WithMany(x => x.TeamSeasons);
            builder.HasKey(x => new {x.TeamId, x.SeasonId });

            builder.Property(x => x.TeamId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.SeasonId)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("TeamSeason");
        }
    }
}
