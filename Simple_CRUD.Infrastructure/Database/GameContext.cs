using Microsoft.EntityFrameworkCore;
using Simple_CRUD.Domain.Entities.Game;

namespace Simple_CRUD.Infrastructure.Database
{
    public class GameContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenre { get; set; }

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
            optionsBuilder
                .LogTo(Console.WriteLine)
                //.EnableDetailedErrors()
                .UseSqlite(_connectionString, b => b.MigrationsAssembly("Simple_CRUD"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>()
                .HasIndex(g => g.Name)
                .IsUnique();
            modelBuilder.Entity<GameGenre>()
                .HasKey(x => new { x.GameId, x.GenreId });

            //modelBuilder.Entity<Game>()
            //    .HasMany(e => e.Genres)
            //    .WithMany(e => e.Games)
            //    .UsingEntity<GameGenre>(
            //        l => l.HasOne<Genre>(e => e.Genre).WithMany(e => e.GameGenres).HasForeignKey(e => e.GenresId),
            //        r => r.HasOne<Game>(e => e.Game).WithMany(e => e.GameGenres).HasForeignKey(e => e.GamesId));

            //modelBuilder.Entity<Genre>()
            //    .HasMany(e => e.Games)
            //    .WithMany(e => e.Genres)
            //    .UsingEntity<GameGenre>(
            //        l => l.HasOne<Game>().WithMany().HasForeignKey(e => e.GamesId),
            //        r => r.HasOne<Genre>().WithMany().HasForeignKey(e => e.GenresId));

            //modelBuilder.Entity<Genre>()
            //    .HasIndex(x => x.Name)
            //    .IsUnique();

            //modelBuilder.Entity<GameGenre>()
            //   .HasNoKey();
            //.HasKey(x => new { x.GameId, x.GenreId });

            //modelBuilder.Entity<GameGenre>()
            //    .HasOne(x => x.Game)
            //    .WithMany(x => x.GameId)
            //    .HasForeignKey(x => x.GameId);

            //modelBuilder.Entity<GameGenre>()
            //    .HasOne(x => x.Genre)
            //    .WithMany(x => x.Games)
            //    .HasForeignKey(x => x.GenreId);
        }
    }
}
