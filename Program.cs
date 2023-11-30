using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApi.Components;
using BlazorApi.DataServices;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient<ISpaceDataService, SpaceDataSerivce>(opts => {
    opts.BaseAddress = new Uri(builder.Configuration["baseUrlSpace"]);
});

builder.Services.AddHttpClient<IFilmsDataService, FilmsDataService>(opts => {
    opts.BaseAddress = new Uri(builder.Configuration["baseUrlFilms"]);
});

builder.Services.AddHttpClient<IRickAndMortyDataService, RickAndMortyDataService>(opts => {
    opts.BaseAddress = new Uri(builder.Configuration["baseUrlRickAndMorty"]);
});

builder.Services.AddHttpClient<IChatGptDataService, ChatGptDataService>(opts => {
    opts.BaseAddress = new Uri(builder.Configuration["baseUrlChatGpt"]);
});

await builder.Build().RunAsync();