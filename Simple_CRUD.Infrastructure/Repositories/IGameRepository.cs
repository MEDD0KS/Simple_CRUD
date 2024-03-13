using Simple_CRUD.Domain.Entities.Game;

namespace Simple_CRUD.Infrastructure.Repositories
{
    public interface IGameRepository
    {
        public void Create(Game item);
        public Game? ReadById(int id);
        public void Update(Game item);
        public void DeleteById(int id);
        public void DeleteByName(string name);
        public void DeleteItem(Game item);
        public void Save();


    }
}
