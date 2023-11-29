using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class CharactersInfo
    {
        [JsonPropertyName("results")]
        public IEnumerable<CharacterInfo> Characters {get;set;}
    }
}