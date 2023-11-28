using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class Character
    {
        [JsonPropertyName("id")]
        public string Id {get;set;}
        [JsonPropertyName("name")]
        public string Name {get;set;}
        [JsonPropertyName("gender")]
        public string Gender {get;set;}
        [JsonPropertyName("image")]
        public string Image {get;set;}
    }
}