namespace Simple_CRUD.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        public void Create(T item);
        public T? ReadById(int id);
        public void Update(T item);
        public void DeleteById(int id);
        public void DeleteItem(T item);


    }
}
