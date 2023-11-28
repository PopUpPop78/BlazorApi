using BlazorApi.Dtos.RickAndMorty;

namespace BlazorApi.DataServices
{
    public interface IRickAndMortyDataService
    {
        Task<CharactersReadAllDto> GetAllCharacters();
    }
}