using Simple_CRUD.Domain.Entities.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_CRUD.Infrastructure.Repositories.Genres
{
    public interface IGenreRepository
    {
        //public void DeleteAllLinkGenre(int gameId);
        public void CreateLinkGenre(Game gameItem, IEnumerable<Genre> genreItem);
        public void Create(Genre item);
        public void DeleteById(int id);
        public Task<Genre> GetById(int id);
        public Task<List<Genre>> GetAll();
        public Task<IQueryable<Genre>> GetListByNames(IEnumerable<string> names);
        public Task Save();
    }
}
