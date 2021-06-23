using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sf_stats.Domain.Entities;


namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class GameEntityConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
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
