using BlazorApi.Dtos.RickAndMorty;

namespace BlazorApi.DataServices
{
    public interface IRickAndMortyDataService
    {
        Task<CharactersReadAllDto> GetAllCharacters();
        Task<CharacterReadDto> GetCharacter(string id);
        Task<EpisodeReadDto> GetEpisode(string id);
    }
}