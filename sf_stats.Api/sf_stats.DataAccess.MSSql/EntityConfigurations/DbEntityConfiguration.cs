using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.DataAccess.MSSql.EntityConfigurations
{
    public class DbEntityConfiguration : IEntityTypeConfiguration<DbEntity>
    {
        public void Configure(EntityTypeBuilder<DbEntity> builder)
        {
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate)
                .HasColumnType("datetimeoffset");

            builder.Property(x => x.LastModifiedDate)
                .HasColumnType("datetimeoffset"); 
        }
    }
}
