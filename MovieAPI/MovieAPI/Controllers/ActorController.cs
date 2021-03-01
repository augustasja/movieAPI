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
    public class ActorController : ControllerBase
    {
        private readonly IActorRepo _actorRepo;

        public ActorController(IActorRepo actorRepo)
        {
            _actorRepo = actorRepo;
        }

        // GET: api/<ActorController>
        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            List<ActorGetDto> actorsDto = new List<ActorGetDto>();
            var actors = await _actorRepo.GetAllAsync();
            foreach (var actor in actors)
            {
                var dto = new ActorGetDto();
                dto.Id = actor.Id;
                dto.Fullname = actor.FullName;
                actorsDto.Add(dto);
            }
            return Ok(actorsDto);
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            var actorById = await _actorRepo.GetByIdAsync(id);

            if (actorById == null)
                return NotFound();
            var actorDto = new ActorGetDto();
            actorDto.Id = actorById.Id;
            actorDto.Fullname = actorById.FullName;

            return Ok(actorDto);
        }

        // POST api/<ActorController>
        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] ActorPutPostDto actorDto)
        {
            if(ModelState.IsValid)
            {
                var newActor = new Actor();
                newActor.FullName = actorDto.FullName;

                var addResult = await _actorRepo.CreateAsync(newActor);
                if (addResult == null)
                    return BadRequest("Actor wasn't added. Try again");
                return Created($"https://localhost:5001/api/actor/{newActor.Id}", newActor); // veliau pasitikslint
            }
            return BadRequest("Proided Model is not valid");
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor([FromBody] ActorPutPostDto actorDto, int id)
        {
            if(ModelState.IsValid)
            {
                var updateActor = new Actor();
                updateActor.Id = id;
                updateActor.FullName = actorDto.FullName;
                var addResult = await _actorRepo.UpdateAsync(updateActor);
                if (addResult == false)
                    return BadRequest("Actor wasn't updated. Try again");
                return Created($"https://localhost:5001/api/actor/{updateActor.Id}", updateActor); // veliau pasitikslint
            }
            return Ok();
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var result = await _actorRepo.DeleteAsync(id);
            if (result)
            {
                return Ok("Actor successfully deleted");
            }
            else
                return BadRequest("Something went wrong.");
        }
    }
}
