using Microsoft.AspNetCore.Mvc;
using Simple_CRUD.Domain.Entities;
using Simple_CRUD.Infrastructure.Repositories;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Simple_CRUD.Web.Controllers
{
    public class GameController: Controller
    {
        private readonly GameRepository _gameRepository;

        public GameController(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpPost()]

        public IActionResult AddGame()
        {
            string body = "";

            using(StreamReader reader = new StreamReader(Request.Body, encoding: Encoding.UTF8))
            {
                body = reader.ReadToEnd();
            }
            try
            {
                var game = JsonSerializer.Deserialize<Game>(body);
                if(game == null) 
                {
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);
                }
                _gameRepository.Create(game);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }

            return new StatusCodeResult(StatusCodes.Status201Created);
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
