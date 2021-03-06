using AutoMapper;
using sf_stats.Domain.Dtos;
using sf_stats.Domain.Entities;

namespace sf_stats.Api.DataMapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<Log, LogDto>().ReverseMap();
            this.CreateMap<Season, SeasonDto>().ReverseMap();
            this.CreateMap<Division, DivisionDto>().ReverseMap();
            this.CreateMap<Player, PlayerDto>().ReverseMap();
            this.CreateMap<Team, TeamDto>().ReverseMap();
            this.CreateMap<TeamSeason, TeamSeasonDto>().ReverseMap();
            this.CreateMap<Game, GameDto>().ReverseMap();
            this.CreateMap<TeamSeasonGame, TeamSeasonGameDto>().ReverseMap();
            this.CreateMap<StatType, StatTypeDto>().ReverseMap();
            this.CreateMap<TeamSeasonPlayer, TeamSeasonPlayerDto>().ReverseMap();
            this.CreateMap<PlayerStat, PlayerStatDto>().ReverseMap();

            // Example for mapping properties directly
            // this.CreateMap<Log, LogDto>().ReverseMap()
            //    .ForMember(dest => dest.Level, opt => opt.MapFrom(org => org.Level));
        }

    }
}
