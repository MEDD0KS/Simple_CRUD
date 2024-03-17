using AutoMapper;
using Simple_CRUD.Application.Dtos;
using Simple_CRUD.Domain.Entities.Game;
using Simple_CRUD.Application.Mapper;
using Simple_CRUD.Infrastructure.Repositories.Games;
using Simple_CRUD.Infrastructure.Repositories.Genres;

namespace Simple_CRUD.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;

        public GameService(IGameRepository gameRepository, IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }

        public async Task<ResultStatus> AddGame(GameAddRequestDto gameAddRequest)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.AddProfile<GameMappingProfile>());
                var mapper = config.CreateMapper();

                var game = mapper.Map<GameAddRequestDto, Game>(gameAddRequest);

                _gameRepository.Create(game);
                await _gameRepository.Save();
               
                var listGenre = _genreRepository.GetListByNames(gameAddRequest.Genres).Result;

                _genreRepository.CreateLinkGenre(gameItem: game, genreItem: listGenre);
                
                
                await _gameRepository.Save();
            }
            catch
            {
                return ResultStatus.Error;
            }
            return ResultStatus.Ok;
        }

        public ResultStatus DeleteGameByName(string name)
        {
            try
            {     
                _gameRepository.DeleteByName(name);
                _gameRepository.Save();
            }
            catch
            {
                return ResultStatus.Error;
            }
            return ResultStatus.Ok;
        }

        public Tuple<Game?, ResultStatus> GetGameById(int id)
        {
            Game? game;

            try
            {
                game = _gameRepository.GetById(id).Result;
                if(game == null)
                {
                    return new Tuple<Game?, ResultStatus>(null, ResultStatus.NotFound);
                }
            }
            catch
            {               
                return new Tuple<Game?, ResultStatus>(null, ResultStatus.Error);
            }
            
            return new Tuple<Game?, ResultStatus>(game, ResultStatus.Ok);
        }

        public ResultStatus UpdateGame(Game game)
        {
            try
            {
                _gameRepository.Update(game);
                _gameRepository.Save();
            }
            catch
            {
                return ResultStatus.Error;
            }
            return ResultStatus.Ok;
        }
    }
}
