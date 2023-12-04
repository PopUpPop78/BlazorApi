using System.ComponentModel.DataAnnotations;
using BlazorApi.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazorApi.Components
{
    public partial class BearerTokenSaver
    {
        [Inject]
        public ILocalStorageService LocalStorageService {get;set;}
        [Inject]
        public IConfiguration Configuration {get;set;}
        [Inject]
        public IJSRuntime JsRuntime {get;set;}

        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public string Message { get; set; }

        private const string DefaultTitle = "ChatGPT Token";
        private const string DefaultMessage = "Save your ChatGPT Bearer Token";
        private const string TokenStorageName = "chatGptBearerCookieKey";

        private bool isToken;

        public string ModalDisplay = "none;";
        public string ModalClass = "";
        public bool ShowBackdrop = false;

        // Forms
        private EditContext editContext;
        public Token Token;

        protected async override Task OnInitializedAsync()
        {
            Title ??= DefaultTitle;
            Message ??= DefaultMessage;
            Initialize();

            isToken = await IsTokenSaved();
        }

        private void Initialize()
        {
            Token = new();
            editContext = new EditContext(Token);          
        }

        private async Task ResetValidation(KeyboardEventArgs e)
        {
            Token.ChatGtp = await JsRuntime.InvokeAsync<string>("getElementText", "txtChatGpt");
            editContext.Validate();
        }

        private void Open()
        {
            ModalDisplay = "block;";
            ModalClass = "Show";
            ShowBackdrop = true;

            Initialize();

            StateHasChanged();
        }

        private void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;

            StateHasChanged();
        }

        private async Task Save()
        {            
            Console.WriteLine("Saving bearer token");
            await LocalStorageService.SetItemAsStringAsync(Configuration[TokenStorageName], Token.ChatGtp);
            isToken = await IsTokenSaved();

            Close();
        }

        private async Task<bool> IsTokenSaved()
        {
            var token = await LocalStorageService.GetItemAsStringAsync(Configuration[TokenStorageName]);
            return !string.IsNullOrWhiteSpace(token);
        }
    }
}