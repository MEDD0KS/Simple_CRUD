using Microsoft.EntityFrameworkCore;
using Simple_CRUD.Domain.Entities;

namespace Simple_CRUD.Infrastructure.Database
{
    public class GameContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }

        private const string _connectionString = "";

        public GameContext(DbContextOptions<GameContext> dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(_connectionString);
        }

    }
}
