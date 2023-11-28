using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class CharactersInfo
    {
        [JsonPropertyName("results")]
        public IEnumerable<Character> Characters {get;set;}
    }
}