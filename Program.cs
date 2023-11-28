using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApi.Components;
using BlazorApi.DataServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<ISpaceDataService, SpaceDataSerivce>(opts => {
    opts.BaseAddress = new Uri(builder.Configuration["baseUrlSpace"]);
});

builder.Services.AddHttpClient<IFilmsDataService, FilmsDataService>(opts => {
    opts.BaseAddress = new Uri(builder.Configuration["baseUrlFilms"]);
});

builder.Services.AddHttpClient<IRickAndMortyDataService, RickAndMortyDataService>(opts => {
    opts.BaseAddress = new Uri(builder.Configuration["baseUrlRickAndMorty"]);
});

await builder.Build().RunAsync();