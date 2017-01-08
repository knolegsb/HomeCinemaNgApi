using AutoMapper;
using HomeCinemaNgApi.Entities;
using HomeCinemaNgApi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinemaNgApi.Web.Infrastructure.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            CreateMap<MovieViewModel, Movie>()
                //.ForMember(m => m.Image, map => map.Ignore())
                .ForMember(m => m.Genre, map => map.Ignore());
        }
    }
}