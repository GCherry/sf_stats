using sf_stats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.NameAbbreviation)
                .IsRequired()
                .HasColumnType("nvarchar(5)");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(1);

            builder.ToTable("Team");
        }
    }
}
