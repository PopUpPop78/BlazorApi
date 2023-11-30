using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.ChatGpt
{
    public class Request
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = "gpt-3.5-turbo-instruct";
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; } = 3000;
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; } = 1;
    }
}