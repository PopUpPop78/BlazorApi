using System.Text;
using System.Text.Json;

namespace BlazorApi.DataServices
{
    public abstract class DataServiceBase(HttpClient client)
    {
        public HttpClient Client { get; } = client;

        public virtual async Task<T> Post<T>(object query) where T : class
        {
            var contentString = JsonSerializer.Serialize(query);
            Console.WriteLine(contentString);
            var content = new StringContent(contentString, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var filmsData = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
                return filmsData;
            }
            else
            {
                //var responseString = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(responseString);
            }

            return null;
        }
    }
}