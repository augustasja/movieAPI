using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Type = "Horror"
                }, 
                new Genre
                {
                    Id = 2,
                    Type = "Drama"
                }, 
                new Genre
                {
                    Id = 3,
                    Type = "Comedy"
                }, 
                new Genre
                {
                    Id = 4,
                    Type = "Action"
                }
            );
        }
        public static void SeedActors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = 1,
                    FullName = "Johny Depp",
                },
                new Actor
                {
                    Id = 2,
                    FullName = "Jason Statham"
                },
                new Actor
                {
                    Id = 3,
                    FullName = "Leonard Di Caprio"
                },
                new Actor
                {
                    Id = 4,
                    FullName = "Angelina Jolie"
                }
            );
        }
        public static void SeedMovies(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Andrenaline",
                    ReleaseDate = DateTime.Now.ToShortDateString(),
                    GenreId = 4
                },
                new Movie
                {
                    Id = 2,
                    Name = "Shutter Island",
                    ReleaseDate = DateTime.Now.ToShortDateString(),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 3,
                    Name = "Pirates Of The Carribean",
                    ReleaseDate = DateTime.Now.ToShortDateString(),
                    GenreId = 4
                },
                new Movie
                {
                    Id = 4,
                    Name = "We Are Smiths",
                    ReleaseDate = DateTime.Now.ToShortDateString(),
                    GenreId = 2
                }
               );
        }

    }
}
