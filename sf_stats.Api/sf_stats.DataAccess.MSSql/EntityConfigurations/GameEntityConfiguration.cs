using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sf_stats.Domain.Entities;


namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class GameEntityConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Division).WithMany(x => x.Games);
            builder.HasOne(x => x.Home_TeamSeason).WithMany(x => x.HomeGames).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Away_TeamSeason).WithMany(x => x.AwayGames).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DivisionId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Home_TeamSeasonId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Away_TeamSeasonId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.GameDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Home_Score)
                .HasColumnType("int");

            builder.Property(x => x.Away_Score)
                .HasColumnType("int");

            builder.ToTable("Game");
        }
    }
}
