using Simple_CRUD.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Simple_CRUD.Domain.Entities.Game;

namespace Simple_CRUD.Infrastructure.Repositories
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
            var removingItem = _gameContext.Games.FirstOrDefault(x => x.Id == id);
            if (removingItem != null)
            {
                _gameContext.Games.Remove(removingItem);
            }
        }

        public void DeleteByName(string name)
        {
            var removingItem = _gameContext.Games.FirstOrDefault(x => x.Title == name);
            //removingItem.Genres = _gameContext.GameGenres.FirstOrDefault(x => x.GameId == )
            if (removingItem != null)
            {
                _gameContext.Games.Remove(removingItem);
            }
        }

        public void DeleteItem(Game item)
        {
            _gameContext.Games.Remove(item);
        }

        public Game? ReadById(int id)
        {
            return _gameContext.Games.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Game item)
        {
            _gameContext.Games.Entry(item).State = EntityState.Modified;
        }

        public void Save() 
        {
            _gameContext.SaveChanges();
        }


    }
}
