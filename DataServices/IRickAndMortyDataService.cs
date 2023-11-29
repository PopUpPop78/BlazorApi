using BlazorApi.Dtos.RickAndMorty;

namespace BlazorApi.DataServices
{
    public interface IRickAndMortyDataService
    {
        Task<CharactersReadAllDto> GetAllCharacters(int page, string filter);
        Task<CharacterReadDto> GetCharacter(string id);
        Task<EpisodeReadDto> GetEpisode(string id);
    }
}