using Microsoft.EntityFrameworkCore;
using Simple_CRUD.Domain.Entities.Game;

namespace Simple_CRUD.Infrastructure.Database
{
    public class GameContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }

        private const string _connectionString = "Data Source = C:/Users/MEDD0KS/source/repos/Simple_CRUD/Simple_CRUD.Infrastructure/Database/baseGames.db";

        public GameContext(DbContextOptions<GameContext> dbContextOptions): base(dbContextOptions)
        {

        }

        public GameContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(_connectionString, b => b.MigrationsAssembly("Simple_CRUD"));
        }


    }
}
