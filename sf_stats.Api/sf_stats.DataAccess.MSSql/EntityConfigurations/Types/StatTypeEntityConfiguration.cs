using sf_stats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class StatTypeEntityConfiguration : IEntityTypeConfiguration<StatType>
    {
        public void Configure(EntityTypeBuilder<StatType> builder)
        {
            builder.Property(x => x.Code)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(x => x.DisplayName)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.ToTable("StatType");
        }
    }
}
