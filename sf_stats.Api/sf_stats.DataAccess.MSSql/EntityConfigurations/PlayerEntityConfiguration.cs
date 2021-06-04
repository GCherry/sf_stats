using sf_stats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class PlayerEntityConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.MiddleName)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.Height)
                .IsRequired()
                .HasColumnType("tinyint");

            builder.Property(x => x.Weight)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(x => x.Grade)
                .HasColumnType("varchar(50)");

            builder.ToTable("Player");
        }
    }
}
