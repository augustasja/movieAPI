using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure
{
    public interface IMovieRepo: IRepo<Movie>
    {
        Task<IEnumerable<Movie>> SearchMovieAsync(string searchTerm);
        Task<IEnumerable<Movie>> SearchByMovieDateAsync(DateTime searchTerm);
        //Task<Actor> AddActor(int movieid, Actor actor);
        //Task<bool> RemoveActor(int movieId, int actorId);
        //Task<bool> UpdateActor(int movieId, Actor updateActor);
    }
}
