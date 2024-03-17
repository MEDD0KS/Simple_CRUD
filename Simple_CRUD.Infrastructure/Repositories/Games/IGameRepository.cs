using Simple_CRUD.Domain.Entities.Game;

namespace Simple_CRUD.Infrastructure.Repositories.Games
{
    public interface IGameRepository
    {
        public void Create(Game item);
        public Task<Game?> GetById(int id);
        public void Update(Game item);
        public void DeleteById(int id);
        public void DeleteByName(string name);
        public Task Save();


    }
}
