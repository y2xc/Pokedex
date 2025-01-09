using pokedex.Models;

namespace pokedex.Services
{
    public interface IPokemonService
    {
        public Task<List<Pokemon>> GetPokemons();
        public Task<Pokemon> GetPokemonById(string id);
        public Task<bool> AddPokemon(Pokemon pokemon);
        public Task<bool> UpdatePokemon(string id, Pokemon pokemon);
        public Task<bool> DeletePokemon(string id);
        public Task<Pokemon> GetPokemonByName(string name);
    }
}