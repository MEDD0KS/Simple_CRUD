using Microsoft.EntityFrameworkCore;

namespace Simple_CRUD.Domain.Entities.Game
{    
    public class Genre : BaseEntity
    {
        
        public string Name { get; set; }
        public List<GameGenre> Games { get; set; } = new();
    }
}
