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
            CreateMap<GameAddRequestDto, Game>();
        }

    }
}
