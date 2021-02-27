using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedGenres();
            modelBuilder.SeedActors();
            modelBuilder.SeedMovies();

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("ActorMovie").HasData(
            new { ActorsId = 1, MoviesId = 1 },
            new { ActorsId = 2, MoviesId = 1 },
            new { ActorsId = 3, MoviesId = 1 },
            new { ActorsId = 1, MoviesId = 2 },
            new { ActorsId = 2, MoviesId = 3 }
        );

            //modelBuilder.SeedSharedEntity();

            //modelBuilder.Entity<Movie>()
            //        .HasMany(x => x.Actors)
            //        .WithMany(x => x.Movies);

        }

    }
}
