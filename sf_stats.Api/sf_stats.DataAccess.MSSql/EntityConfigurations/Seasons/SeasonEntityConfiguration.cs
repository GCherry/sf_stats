using sf_stats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class SeasonEntityConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasOne(x => x.Division).WithMany(x => x.Seasons);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(x => x.DisplayName)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.StartDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.EndDate)
                .IsRequired()
                .HasColumnType("date");

            builder.ToTable("Season");
        }
    }
}
