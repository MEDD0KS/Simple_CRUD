namespace Simple_CRUD.Domain.Entities.Game
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Description { get; set; }
        public DateTime RelizeDate { get; set; }
        public double Price { get; set; }
        public List<GameGenre> Genres { get; set; } = new();
        public double Rating { get; set; }

    }
}
