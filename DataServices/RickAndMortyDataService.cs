using BlazorApi.Dtos.RickAndMorty;

namespace BlazorApi.DataServices
{
    public class RickAndMortyDataService(HttpClient client) : DataServiceBase(client), IRickAndMortyDataService
    {
        public async Task<CharactersReadAllDto> GetAllCharacters()
        {
            var query = new 
            {
                query = "{characters(page: 1, filter: { name: \"rick\" }) {results {id name image gender}}}"
            };

            return await Post<CharactersReadAllDto>(query);
        }

        public async Task<CharacterReadDto> GetCharacter(string id)
        {
            var query = new 
            {
                query = "{character(id:" + id + ") {id image name gender type status species location { id name } origin { name } episode { id name }}}"
            };

            return await Post<CharacterReadDto>(query);
        }

        public async Task<EpisodeReadDto> GetEpisode(string id)
        {
            var query = new 
            {
                query = "{episode(id:" + id + ") {id name episode air_date characters {id name}}}"
            };

            return await Post<EpisodeReadDto>(query);
        }
    }
}