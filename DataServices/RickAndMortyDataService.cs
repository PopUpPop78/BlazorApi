using BlazorApi.Dtos.RickAndMorty;

namespace BlazorApi.DataServices
{
    public class RickAndMortyDataService(HttpClient client) : DataServiceBase(client), IRickAndMortyDataService
    {
        public async Task<CharactersReadAllDto> GetAllCharacters()
        {
            var query = new 
            {
                query = "{characters {results {id name image gender}}}"
            };

            return await Post<CharactersReadAllDto>(query);
        }
    }
}