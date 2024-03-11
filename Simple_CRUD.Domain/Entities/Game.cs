namespace Simple_CRUD.Domain.Entities
{
    public class Game: BaseEntity
    {
        public string Title { get; set; }
        public string Developer {  get; set; }
        public string Description { get; set; }
        public TimeSpan RelizeDate { get; set; }
        public double Price { get; set; }    
        public GameGenre[] Genres { get; set; }
        public double Rating { get; set; }
        
    }
}
