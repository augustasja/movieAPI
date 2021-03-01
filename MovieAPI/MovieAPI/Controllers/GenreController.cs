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
    [Route("/api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepo _genreRepo;

        public GenreController(IGenreRepo genreRepo)
        {
            _genreRepo = genreRepo;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            List<GenreGetDto> genresDto = new List<GenreGetDto>();
            var genres = await _genreRepo.GetAllAsync();
            foreach (var genre in genres)
            {
                var dto = new GenreGetDto();
                dto.Id = genre.Id;
                dto.Type = genre.Type;
                genresDto.Add(dto);
            }
            return Ok(genresDto);
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genreById = await _genreRepo.GetByIdAsync(id);

            if (genreById == null)
                return NotFound();
            var genreDto = new GenreGetDto();
            genreDto.Id = genreById.Id;
            genreDto.Type = genreById.Type;

            return Ok(genreDto);
        }

        // POST api/<GenreController>
        [HttpPost]
        public async Task<IActionResult>CreateGenre([FromBody] GenrePutPostDto genreDto)
        {
            if(ModelState.IsValid)
            {
                var newGenre = new Genre();
                newGenre.Type = genreDto.Type;
                var addResult = await _genreRepo.CreateAsync(newGenre);
                if (addResult == null)
                    return BadRequest("Genre wasn't added. Try again");
                return Created($"https://localhost:5001/api/genre/{newGenre.Id}", genreDto);
            }
            return BadRequest("Provided Model is not valid");
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre([FromBody] GenrePutPostDto genreDto, int id)
        {
            if(ModelState.IsValid)
            {
                var updateGenre = new Genre();
                updateGenre.Id = id;
                updateGenre.Type = genreDto.Type;

                var result = await _genreRepo.UpdateAsync(updateGenre);
                if (result)
                    return Ok("Genre was updated successfully");
                return BadRequest("Couldn't update genre");
            }
            return BadRequest("Provided Model is not valid");
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {

            var result = await _genreRepo.DeleteAsync(id);
            if (result)
            {
                return Ok("Genre successfully deleted");
            }
            else
                return BadRequest("Something went wrong.");
        }
    }
}
