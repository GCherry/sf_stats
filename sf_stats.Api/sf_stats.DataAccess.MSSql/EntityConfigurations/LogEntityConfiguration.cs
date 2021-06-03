using sf_stats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class LogEntityConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Message)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.MessageTemplate)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Level)
                .HasColumnType("nvarchar(128)")
                .IsRequired();

            builder.Property(x => x.TimeStamp)
                .HasColumnType("datetimeoffset(7)")
                .IsRequired();

            builder.Property(x => x.Exception)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Properties)
                .HasColumnType("xml");

            builder.Property(x => x.LogEvent)
                .HasColumnType("nvarchar(max)");

            builder.ToTable("Log");
        }
    }
}
