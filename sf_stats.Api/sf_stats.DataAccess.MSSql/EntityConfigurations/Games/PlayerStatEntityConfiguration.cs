using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sf_stats.Domain.Entities;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    class PlayerStatEntityConfiguration : IEntityTypeConfiguration<PlayerStat>
    {
        public void Configure(EntityTypeBuilder<PlayerStat> builder)
        {
            builder.HasOne(x => x.TeamSeasonPlayer).WithMany(x => x.PlayerStats);
            builder.HasOne(x => x.Game).WithMany(x => x.PlayerStats);
            builder.HasOne(x => x.StatType).WithMany(x => x.PlayerStats);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.GameId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.TeamSeasonPlayerId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.StatTypeId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType("decimal");

            builder.ToTable("PlayerStat");
        }
    }
}