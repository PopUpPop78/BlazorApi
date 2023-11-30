using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BlazorApi.DataServices
{
    public abstract class DataServiceBase(HttpClient client)
    {
        protected const string ApplicationJson = "application/json";

        // We use this unrelaxed encoding in order to maintain double quotes with empty filter string
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions 
        {
             WriteIndented = true,
             Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
             
        };

        public HttpClient Client { get; } = client;

        public virtual async Task<T> Post<T>(object query) where T : class
        {
            var contentString = JsonSerializer.Serialize(query, options);

            Console.WriteLine(contentString);
            var content = new StringContent(contentString, Encoding.UTF8, ApplicationJson);

            var response = await Client.PostAsync(string.Empty, content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), options);
                return data;
            }
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }

            return null;
        }

        public virtual async Task<T> Post<T>(string url, object query) where T : class
        {
            var contentString = JsonSerializer.Serialize(query, options);

            Console.WriteLine(contentString);
            var content = new StringContent(contentString, Encoding.UTF8, ApplicationJson);

            var response = await Client.PostAsync(url, content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), options);
                return data;
            }
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }

            return null;
        }
    }
}