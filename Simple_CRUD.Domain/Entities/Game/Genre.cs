using Microsoft.EntityFrameworkCore;

namespace Simple_CRUD.Domain.Entities.Game
{    
    public class Genre : BaseEntity
    {        
        public string Name { get; set; }
        //public List<Game> Games { get; set; } = [];
        //public List<GameGenre> GameGenres { get; set; } = [];
    }
}
