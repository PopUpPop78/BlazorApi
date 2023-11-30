namespace BlazorApi.DataServices
{
    public interface IChatGptDataService
    {
        Task<string> GetAnswer(string question, string bearerToken);
    }
}