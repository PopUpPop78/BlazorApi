using BlazorApi.Dtos.RickAndMorty;

namespace BlazorApi.DataServices
{
    public class RickAndMortyDataService(HttpClient client) : DataServiceBase(client), IRickAndMortyDataService
    {
        public async Task<CharactersReadAllDto> GetAllCharacters(int page, string filterText)
        {
            var query = new 
            {
                query = "{characters(page: " + page + ", filter: { name: \"" + filterText + "\" }) {info {pages count} results {id name image gender}}}"
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
                query = "{episode(id:" + id + ") {id name episode air_date characters {id name image}}}"
            };

            return await Post<EpisodeReadDto>(query);
        }
    }
}