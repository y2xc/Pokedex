using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using pokedex.Services;

namespace pokedex.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService? _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPokemons()
        {
            try
            {
                return Ok(await _pokemonService?.GetPokemons()!);
            }
            catch (Exception)
            {
                return NotFound("There are No Pokemons Saved in the database");
            }
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult> GetPokemonById(string id)
        {
            try
            {
                return Ok(await _pokemonService?.GetPokemonById(id)!);
            }
            catch (Exception)
            {
                return NotFound($"There is no Pokemon with id => {id}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddPokemon(Pokemon newPokemon)
        {
            try
            {
                if (await _pokemonService?.AddPokemon(newPokemon)! == true)
                {
                    return Ok("Pokemon Added Successfully");
                }
                else
                {
                    return BadRequest("Failed to Add Pokemon");
                }
            }
            catch (Exception)
            {
                return BadRequest("Failed to Add Pokemon");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePokemon(string id, Pokemon currPokemon)
        {
            try{
                if(await _pokemonService?.UpdatePokemon(id, currPokemon)! == true){
                    return Ok("Pokemon Updated Successfully");
                } else {
                    return BadRequest("Failed to Update Pokemon");
                }
            } catch(Exception){
                return BadRequest("Failed to Update Pokemon");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePokemon(string id){
            try{
                if(await _pokemonService?.DeletePokemon(id)! == true){
                    return Ok("Pokemon Deleted Successfully");
                } else{
                    return BadRequest("Failed to Delete Pokemon");
                }
            }catch(Exception){
                return BadRequest("Failed to Delete Pokemon");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> GetPokemonByName(string name){
            try{
                if(await _pokemonService?.GetPokemonByName(name)! != null){
                    return Ok(await _pokemonService?.GetPokemonByName(name)!);
                } else {
                    return NotFound($"There is no Pokemon with name => {name}");
                }
                
            }
            catch(Exception){
                return NotFound($"There is no Pokemon with name => {name}");
            }
        }
    }
}
