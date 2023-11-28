using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class Data
    {
        [JsonPropertyName("characters")]
        public CharactersInfo CharactersInfo {get;set;}
    }
}