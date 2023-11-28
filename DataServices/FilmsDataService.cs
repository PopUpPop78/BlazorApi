using BlazorApi.Dtos;

namespace BlazorApi.DataServices
{
    public class FilmsDataService(HttpClient client) : DataServiceBase(client), IFilmsDataService
    {
        public async Task<FilmsReadDto> GetFilmsInfo()
        {
            var query = new 
            {
                query = "{allFilms {films {title director releaseDate}}}"
            };
            
            return await Post<FilmsReadDto>(query);
        }
    }
}