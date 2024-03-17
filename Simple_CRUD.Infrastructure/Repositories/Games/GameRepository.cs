using Simple_CRUD.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Simple_CRUD.Domain.Entities.Game;
using System.Xml.Linq;

namespace Simple_CRUD.Infrastructure.Repositories.Games
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _gameContext;

        public GameRepository(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void Create(Game item)
        {
            _gameContext.Games.Add(item);
        }

        public void DeleteById(int id)
        {
            var item = new Game() { Id = id };
            _gameContext.Games.Remove(item);
            //var removingItem = _gameContext.GameGenre.Where(x => x.GameId == id);
            //_gameContext.GameGenre.RemoveRange(removingItem);
        }

        public void DeleteByName(string name)
        {
            var removingItem = _gameContext.Games.FirstOrDefault(x => x.Title == name);
            if (removingItem != null)
            {
                _gameContext.Games.Remove(removingItem);
            }
        }

        public Task<Game?> GetById(int id)
        {
            return _gameContext.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Game item)
        {
            _gameContext.Games.Entry(item).State = EntityState.Modified;
        }

        public async Task Save()
        {
           await _gameContext.SaveChangesAsync();            
        }
    }
}
