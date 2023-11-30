using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class Info
    {
        [JsonPropertyName("pages")]
        public int? Pages {get;set;}
        [JsonPropertyName("count")]
        public int? Count {get;set;}
    }
}