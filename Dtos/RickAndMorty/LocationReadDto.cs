using System.Text.Json.Serialization;
using BlazorApi.Dtos.RickAndMorty;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class LocationReadDto
    {
        [JsonPropertyName("data")]
        public Data Data {get;set;}
    }
}