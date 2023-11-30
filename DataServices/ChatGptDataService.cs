using BlazorApi.Dtos.ChatGpt;

namespace BlazorApi.DataServices
{
    public class ChatGptDataService(HttpClient client) : DataServiceBase(client), IChatGptDataService
    {
        public async Task<string> GetAnswer(string question, string bearerToken)
        {
            var request = new Request {Prompt = question};

            Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");

            try
            {
                var response = await Post<Response>(request);
                return response?.Choices?.FirstOrDefault()?.Text;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error orrucred {ex.Message}");
                return $"Could NOT answer question: {question}";
            }
        }
    }
}