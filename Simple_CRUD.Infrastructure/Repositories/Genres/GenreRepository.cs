using Microsoft.EntityFrameworkCore;
using Simple_CRUD.Domain.Entities.Game;
using Simple_CRUD.Infrastructure.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_CRUD.Infrastructure.Repositories.Genres
{
    public class GenreRepository : IGenreRepository
    {
        private readonly GameContext _gameContext;

        public GenreRepository(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void CreateLinkGenre(Game gameItem, IEnumerable<Genre> genreItem)
        {
            List<GameGenre> listGameGenre = [];
            var gameId = gameItem.Id;
            
            foreach (var genre in genreItem)
            {
                listGameGenre.Add(new GameGenre() { GameId = gameId, GenreId = genre.Id });
            }
            _gameContext.GameGenre.AddRange(listGameGenre);
        }

        //public void DeleteAllLinkGenre(int gameId)
        //{
        //    var list = _gameContext.GameGenre.Where(x => x.GameId == gameId);
        //    //var list = _gameContext.Genres.Select(x => x.Name).Intersect(names);
        //    //return _gameContext.Genres.Where(x => list.Contains(x.Name));
        //
        //    _gameContext.GameGenre.RemoveRange(list);
        //}
        //
        //public void DeleteLinkGenre(int gameId, int genreId)
        //{
        //    var deletedItem = new GameGenre { GameId = gameId, GenreId = genreId };
        //    var item = _gameContext.GameGenre.FirstOrDefault(x => x == deletedItem);
        //
        //    _gameContext.GameGenre.Remove(item);
        //}

        public void Create(Genre item)
        {
            _gameContext.Genres.Add(item);            
        }

        public void DeleteById(int id)
        {
            var item = new Genre() { Id = id };
            _gameContext.Genres.Remove(item);
        }

        public Task<List<Genre>> GetAll()
        {
            return _gameContext.Genres.ToListAsync();
        }

        public Task<Genre> GetById(int id)
        {
            return _gameContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<IQueryable<Genre>> GetListByNames(IEnumerable<string> names)
        {   
            var list = _gameContext.Genres.Select(x => x.Name).Intersect(names);
            return _gameContext.Genres.Where(x => list.Contains(x.Name));
        }

        public Task Save()
        {
            return _gameContext.SaveChangesAsync();
        }
    }
}
