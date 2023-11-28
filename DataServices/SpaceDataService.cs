using System.Net.Http.Json;
using BlazorApi.Dtos.Space;

namespace BlazorApi.DataServices
{
    public class SpaceDataSerivce(HttpClient client) : ISpaceDataService
    {
        private readonly HttpClient _client = client;

        public async Task<SpaceAgenciesDto> GetSpaceAgencies() => await _client.GetFromJsonAsync<SpaceAgenciesDto>("agencies/?format=json");
    }
}