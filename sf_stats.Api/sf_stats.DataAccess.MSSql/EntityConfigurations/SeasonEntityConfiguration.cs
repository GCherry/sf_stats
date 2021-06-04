﻿using sf_stats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class SeasonEntityConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Code)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(x => x.DisplayName)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.ToTable("Season");
        }
    }
}
