using neptun.API.DTO;
using Core.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neptun.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDTO>()
                .ForMember(d => d.Genres, o => o.MapFrom(s => s.Genres.Select(t => t.Name).ToList()));
            CreateMap<Showing, ShowingDTO>()
                .ForMember(d => d.TheatreName, o => o.MapFrom(s => s.Theatre.Name));
                
        }
    }
}
