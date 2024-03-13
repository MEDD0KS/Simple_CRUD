using AutoMapper;
using Simple_CRUD.Application.Dtos;
using Simple_CRUD.Domain.Entities.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_CRUD.Application.Mapper
{
    public class GameMappingProfile: Profile
    {
        public GameMappingProfile() 
        {
            CreateMap<GameAddRequestDto, Game>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
                .ReverseMap();

            CreateMap<GenreAddRequestDto, Genre>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
        }

    }
}
