using BlazorApi.DataServices;
using BlazorApi.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazorApi.Components
{
    public partial class AskChatGpt
    {
        [Inject]
        public IJSRuntime JsRuntime {get;set;}        
        [Inject]
        public IChatGptDataService ChatGptDataService {get;set;}
        [Inject]
        public ILocalStorageService LocalStorageService {get;set;}
        [Inject]
        public IConfiguration Configuration {get;set;}

        [Parameter]
        public bool IsAnswerOnly {get;set;} = false;

        [Parameter]
        public ChatGptModel Model {get;set;} = new();

        private EditContext editContext;
        private bool isLoading = false;
        private string flash;

        protected async override Task OnInitializedAsync()
        {
            if(!IsAnswerOnly)
            {
                editContext = new EditContext(Model);                
                await Task.CompletedTask;

                return;
            }

            _ = GetOpinionFromChatGtp();
        }

        private async Task ResetValidation(KeyboardEventArgs e)
        {
            Model.Question = await JsRuntime.InvokeAsync<string>("getElementText", "txtAskChatGpt");
            editContext.Validate();
        }

        public async Task ClearAnswer()
        {
            Model.Answer = "";
            await Task.CompletedTask;
        }

        private async Task GetOpinionFromChatGtp()
        {
            try
            {
                Model.Answer = "";
                flash = "";
                isLoading = true;

                Console.WriteLine($"Asking ChatGPT: {Model.Question}");
                var token = await LocalStorageService.GetItemAsStringAsync(Configuration["chatGptBearerCookieKey"]);
                if(string.IsNullOrWhiteSpace(token))
                {
                    Model.Answer = "There is no ChatGPT bearer token saved. Either save a token or goto https://platform.openai.com/ in order to create one";
                    return;
                }

                Model.Answer = await ChatGptDataService.GetAnswer(Model.Question, token);
            }
            finally
            {
                isLoading = false;
                flash = "flash";
                StateHasChanged();
            }
        }
    }
}