﻿using AutoMapper;
using sf_stats.Domain.Dtos;
using sf_stats.Domain.Entities;

namespace sf_stats.Api.DataMapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<Log, LogDto>().ReverseMap();

            // Example for mapping properties directly
            // this.CreateMap<Log, LogDto>().ReverseMap()
            //    .ForMember(dest => dest.Level, opt => opt.MapFrom(org => org.Level));
        }

    }
}