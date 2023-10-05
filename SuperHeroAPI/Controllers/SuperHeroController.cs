using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _service;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _service = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult <List<SuperHero>>> GetAllHeroes()
        {
            return await _service.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHeroes(int id)
        {
            
            var hero = await _service.GetSingleHero(id);
            if (hero is null)
            {
                return NotFound("No hero");
            }
            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero request)
        {

            var hero = await _service.AddHero(request);
            return Ok(hero);
        }

        [HttpPut("id")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = await _service.UpdateHero(id,request);
            if (result is null)
            {
                return NotFound("sorry, this hero doesn't exist");
            }
           
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _service.DeleteHero(id);
            if (result is null)
            {
                return NotFound("sorry, this hero doesn't exist");
            }
            return Ok(result);
        }
    }
}
