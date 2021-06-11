﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sf_stats.DataAccess.MSSql.Context;

namespace sf_stats.DataAccess.MSSql.Migrations
{
    [DbContext(typeof(SFStatDbContext))]
    partial class SFStatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sf_stats.Domain.Entities.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Away_Score")
                        .HasColumnType("int");

                    b.Property<int>("Away_TeamSeasonId")
                        .HasColumnType("int");

                    b.Property<int>("Away_TeamSeasonSeasonId")
                        .HasColumnType("int");

                    b.Property<int>("Away_TeamSeasonTeamId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DivisionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("Home_Score")
                        .HasColumnType("int");

                    b.Property<int>("Home_TeamSeasonId")
                        .HasColumnType("int");

                    b.Property<int>("Home_TeamSeasonSeasonId")
                        .HasColumnType("int");

                    b.Property<int>("Home_TeamSeasonTeamId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("Away_TeamSeasonTeamId", "Away_TeamSeasonSeasonId");

                    b.HasIndex("Home_TeamSeasonTeamId", "Home_TeamSeasonSeasonId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LogEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageTemplate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .HasColumnType("xml");

                    b.Property<DateTimeOffset>("TimeStamp")
                        .HasColumnType("datetimeoffset(7)");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasColumnType("varchar(50)");

                    b.Property<byte>("Height")
                        .HasColumnType("tinyint");

                    b.Property<DateTimeOffset>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Weight")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.PlayerStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("StatTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("StatTypeId");

                    b.ToTable("PlayerStat");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTimeOffset>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Season");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.StatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("StatType");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.TeamSeason", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("TeamId", "SeasonId");

                    b.HasIndex("SeasonId");

                    b.ToTable("TeamSeason");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.TeamSeasonPlayer", b =>
                {
                    b.Property<int>("TeamSeasonId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TeamSeasonSeasonId")
                        .HasColumnType("int");

                    b.Property<int>("TeamSeasonTeamId")
                        .HasColumnType("int");

                    b.HasKey("TeamSeasonId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamSeasonTeamId", "TeamSeasonSeasonId");

                    b.ToTable("TeamSeasonPlayer");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Game", b =>
                {
                    b.HasOne("sf_stats.Domain.Entities.Division", "Division")
                        .WithMany("Games")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf_stats.Domain.Entities.TeamSeason", "Away_TeamSeason")
                        .WithMany("AwayGames")
                        .HasForeignKey("Away_TeamSeasonTeamId", "Away_TeamSeasonSeasonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("sf_stats.Domain.Entities.TeamSeason", "Home_TeamSeason")
                        .WithMany("HomeGames")
                        .HasForeignKey("Home_TeamSeasonTeamId", "Home_TeamSeasonSeasonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Away_TeamSeason");

                    b.Navigation("Division");

                    b.Navigation("Home_TeamSeason");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.PlayerStat", b =>
                {
                    b.HasOne("sf_stats.Domain.Entities.Game", "Game")
                        .WithMany("PlayerStats")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf_stats.Domain.Entities.Player", "Player")
                        .WithMany("PlayerStats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf_stats.Domain.Entities.StatType", "StatType")
                        .WithMany("PlayerStats")
                        .HasForeignKey("StatTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");

                    b.Navigation("StatType");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.TeamSeason", b =>
                {
                    b.HasOne("sf_stats.Domain.Entities.Season", "Season")
                        .WithMany("TeamSeasons")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf_stats.Domain.Entities.Team", "Team")
                        .WithMany("TeamSeasons")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.TeamSeasonPlayer", b =>
                {
                    b.HasOne("sf_stats.Domain.Entities.Player", "Player")
                        .WithMany("TeamSeasonPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf_stats.Domain.Entities.TeamSeason", "TeamSeason")
                        .WithMany("TeamSeasonPlayers")
                        .HasForeignKey("TeamSeasonTeamId", "TeamSeasonSeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("TeamSeason");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Division", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Game", b =>
                {
                    b.Navigation("PlayerStats");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Player", b =>
                {
                    b.Navigation("PlayerStats");

                    b.Navigation("TeamSeasonPlayers");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Season", b =>
                {
                    b.Navigation("TeamSeasons");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.StatType", b =>
                {
                    b.Navigation("PlayerStats");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.Team", b =>
                {
                    b.Navigation("TeamSeasons");
                });

            modelBuilder.Entity("sf_stats.Domain.Entities.TeamSeason", b =>
                {
                    b.Navigation("AwayGames");

                    b.Navigation("HomeGames");

                    b.Navigation("TeamSeasonPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
