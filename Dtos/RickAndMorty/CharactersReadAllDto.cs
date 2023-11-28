using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{

    public class CharactersReadAllDto
    {
        [JsonPropertyName("data")]
        public Data Data {get;set;}
    }
}