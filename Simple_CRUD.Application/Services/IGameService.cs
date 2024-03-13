using Simple_CRUD.Domain.Entities.Game;
using Simple_CRUD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_CRUD.Application.Services
{
    public interface IGameService
    {
        public ResultStatus AddGame(GameAddRequestDto gameAddRequest);
        public ResultStatus UpdateGame(Game game);
        public ResultStatus DeleteGame(Game game);
        public ResultStatus DeleteGameByName(string name);
        public Tuple<Game?, ResultStatus> GetGameById(int id);
    }
}
