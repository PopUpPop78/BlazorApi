using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class EpisodeReadDto
    {
        [JsonPropertyName("data")]
        public Data Data {get;set;}
    }
}