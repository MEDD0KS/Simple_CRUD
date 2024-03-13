using Simple_CRUD.Domain.Entities.Game;

namespace Simple_CRUD.Web.Entities
{
    public class GameAddRequestDTO
    {
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Description { get; set; }
        public DateTime RelizeDate { get; set; }
        public double Price { get; set; }
        public List<GenreAddRequest> Genres { get; set; } = new();
        public double Rating { get; set; }
    }

    public class GenreAddRequest
    {
        public string Title { get; set; }
    }
}
