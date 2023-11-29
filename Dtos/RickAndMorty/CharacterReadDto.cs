using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class CharacterReadDto
    {
        [JsonPropertyName("data")]
        public Data Data {get;set;}
    }
}