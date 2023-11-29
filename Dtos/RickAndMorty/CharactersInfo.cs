using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class CharactersInfo
    {
        [JsonPropertyName("info")]
        public Info Info {get;set;}
        [JsonPropertyName("results")]
        public IEnumerable<CharacterInfo> Characters {get;set;}
    }
}