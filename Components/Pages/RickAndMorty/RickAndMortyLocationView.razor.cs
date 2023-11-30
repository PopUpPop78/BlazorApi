using BlazorApi.DataServices;
using BlazorApi.Dtos.RickAndMorty;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components.Pages.RickAndMorty
{
    public partial class RickAndMortyLocationView
    {
        [Inject]
        public IRickAndMortyDataService RickAndMortyDataService {get;set;}
        [Inject]
        public NavigationManager NavManager {get;set;}
        [Parameter]
        public string Id {get;set;}

        private LocationInfo location;

        protected async override Task OnInitializedAsync()
        {
            if(Id == null)
                return;
                
            var locationDto = await RickAndMortyDataService.GetLocation(Id);

            if(locationDto != null)
                location = locationDto.Data.LocationInfo;
        }

        private void ViewCharacter(string characterId)
        {
            Console.WriteLine($"Navigating to character {characterId}");
            NavManager.NavigateTo($"/characterView/{characterId}");
        }
    }
}