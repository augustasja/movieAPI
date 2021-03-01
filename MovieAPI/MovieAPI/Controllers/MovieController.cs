using Microsoft.AspNetCore.Mvc;
using MovieAPI.Dto;
using MovieAPI.Infrastructure;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _movieRepo;
        private readonly IActorRepo _actorRepo;

        public MovieController(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public async Task<IActionResult> GetAllMovies(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var result = await _movieRepo.SearchMovieAsync(search);
                result.ToList();
                List<MovieGetDto> searchedMovies = new List<MovieGetDto>();
                foreach (var item in result)
                {
                    var dto = new MovieGetDto();
                    dto.Id = item.Id;
                    dto.Name = item.Name;
                    dto.ReleaseDate = item.ReleaseDate;
                    dto.GenreName = item.MovieGenre.Type;
                    dto.Actors = item.Actors;
                    searchedMovies.Add(dto);

                }
                if (result.Any())
                    return Ok(searchedMovies);

            }

            List<MovieGetDto> moviesDto = new List<MovieGetDto>();
            var movies = await _movieRepo.GetAllAsync();
            foreach (var movie in movies)
            {
                var dto = new MovieGetDto();
                dto.Id = movie.Id;
                dto.Name = movie.Name;
                dto.ReleaseDate = movie.ReleaseDate;
                dto.GenreName = movie.MovieGenre.Type;
                dto.Actors = movie.Actors;
                moviesDto.Add(dto);
            }
            return Ok(moviesDto);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movieById = await _movieRepo.GetByIdAsync(id);

            if (movieById == null)
                return NotFound();
            var movieDto = new MovieGetDto();
            movieDto.Id = movieById.Id;
            movieDto.Name = movieById.Name;
            movieDto.ReleaseDate = movieById.ReleaseDate;
            movieDto.GenreName = movieById.MovieGenre.Type;
            movieDto.Actors = movieById.Actors;

            return Ok(movieDto);
        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MoviePutPostDto movieDto)
        {
            if (ModelState.IsValid)
            {
                var newMovie = new Movie();
                newMovie.Name = movieDto.Name;
                newMovie.ReleaseDate = movieDto.ReleaseDate;
                newMovie.GenreId = movieDto.GenreId;
                //newMovie.Actors = movieDto.Actors;
                newMovie.Actors = new List<Actor>();
                if(movieDto.Actors != null)
                {
                    foreach (var actor in movieDto.Actors)
                    {
                        var updateMovieActor = movieDto.Actors.FirstOrDefault(a => a.Id == actor.Id);
                        updateMovieActor.FullName = actor.FullName;
                        newMovie.Actors.Add(updateMovieActor);
                    }
                }

                var addResult = await _movieRepo.CreateAsync(newMovie);
                if (addResult == null)
                    return BadRequest("Movie wasn't added. Try again.");
                return Created($"https://localhost:5001/api/movie/{newMovie.Id}", addResult);
            }
            return BadRequest("Provided Model is not valid");
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromBody] MoviePutPostDto updateMovieDto, int id)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie();
                movie.Id = id;
                movie.Name = updateMovieDto.Name;
                movie.ReleaseDate = updateMovieDto.ReleaseDate;
                movie.GenreId = updateMovieDto.GenreId;
                movie.Actors = new List<Actor>();
                if(updateMovieDto.Actors != null)
                {
                    foreach (var actor in updateMovieDto.Actors)
                    {
                        var updateActor = new Actor();
                        updateActor = updateMovieDto.Actors.FirstOrDefault(a => a.Id == actor.Id);
                        if (!actor.FullName.Contains(updateActor.FullName))
                        {
                            updateActor.FullName = actor.FullName;
                            movie.Actors.Add(updateActor);
                        }

                    }
                }

                var updateResult = await _movieRepo.UpdateAsync(movie);
                if (updateResult)
                    return Ok("Movie was updated successfully");
                return BadRequest("Couldn't update movie. Please try again.");

            }
            return BadRequest("Provided Model is not valid");
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieRepo.DeleteAsync(id);
            if (result)
            {
                return Ok("Movie successfully deleted");
            }
            else
                return BadRequest("Something went wrong.");
        }

        [HttpGet("{search}/name")]
        public async Task<IActionResult> SearchByName(string search)
        {
            var result = await _movieRepo.SearchMovieAsync(search);
            if (result.Any())
                return Ok(result);
            else
                return NotFound();
        }
    }
}
