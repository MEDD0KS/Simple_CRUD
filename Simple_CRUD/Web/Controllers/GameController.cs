using Microsoft.AspNetCore.Mvc;
using Simple_CRUD.Application.Services;
using Simple_CRUD.Domain.Entities.Game;
using Simple_CRUD.Infrastructure.Repositories;
using Simple_CRUD.Application.Dtos;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Simple_CRUD.Web.Controllers
{
    public class GameController: Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("api/v1/[action]")]
        public IActionResult AddGame([FromBody] GameAddRequestDto GameAddRequest)
        {            
            //TODO - check validate status
            var status = _gameService.AddGame(GameAddRequest);
            
            if(status == ResultStatus.Error) return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        [HttpPost("api/v1/[action]")]
        public IActionResult UpdateGame([FromBody] Game gameData)
        {
            //TODO - check validate status, validate input data
            var status = _gameService.UpdateGame(gameData);

            if (status == ResultStatus.Error) return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        [HttpPost("api/v1/[action]")]
        public IActionResult DeleteGame([FromBody] Game gameData)
        {
            //TODO - check validate status
            var status = _gameService.DeleteGame(gameData);

            if (status == ResultStatus.Error) return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        [HttpPost("api/v1/[action]")]
        public IActionResult DeleteGameByName(string name)
        {
            //TODO - check validate status
            var status = _gameService.DeleteGameByName(name);

            if (status == ResultStatus.Error) return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        [HttpGet("api/v1/[action]")]
        public async Task<IActionResult> ReadGame (int id)
        {
            var responce = new ContentResult();
            //TODO - check validate status
            var status = _gameService.GetGameById(id);

            if (status.Item2 == ResultStatus.Error) return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            if (status.Item2 == ResultStatus.NotFound) return new StatusCodeResult(StatusCodes.Status204NoContent);

            try
            {
                //var data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize<Game>(status.Item1));
                var data = JsonSerializer.Serialize<Game>(status.Item1);
                responce.ContentType = "application/json";
                responce.Content = data;
                //await Response.Body.WriteAsync(data);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            

            return responce;
        }



        [HttpGet]
        public IActionResult Index() 
        { 
            ContentResult responce = new ContentResult();

            responce.Content = "Hello World!";

            return responce;
        }
    }
}
