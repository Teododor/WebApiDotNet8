using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Controllers.Data;
using SuperHeroAPI_DotNet8.Controllers.Entities;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllHeroes()
        {

            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task <IActionResult> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id); 
            if(hero is null)
                return NotFound("Here not found"); //return BadRequest("Hero not found");
                                                  // the parameter here is only a message. It is optional
            return Ok(hero);

        }

        [HttpPost]
        public async Task<IActionResult> AddHero(SuperHero hero) // here instead of the paramter the better idea is to use a DTO (data transfer object, where you put only the data you want to see in your request)
        {
            _context.SuperHeroes.Add(hero);
            //this will not save the change

            await _context.SaveChangesAsync(); 

            return Ok(await GetAllHeroes());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHero(SuperHero hero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);
            if (hero is null)
                return NotFound("Here not found");

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero is null)
                return NotFound("Here to be deleted not Found");

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());

        }

     }
}

