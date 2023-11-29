using BlazorApi.DataServices;
using BlazorApi.Dtos.RickAndMorty;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components.Pages.RickAndMorty
{
    public partial class RickAndMortyEpisodeView
    {
        [Inject]
        public IRickAndMortyDataService RickAndMortyDataService {get;set;}
        [Inject]
        public NavigationManager NavManager {get;set;}
        [Parameter]
        public string Id {get;set;}

        private EpisodeInfo episode;

        protected async override Task OnInitializedAsync()
        {
            var episodeDto = await RickAndMortyDataService.GetEpisode(Id);

            if(episodeDto != null)
                episode = episodeDto.Data.Episode;
        }

        private void ViewCharacter(string characterId)
        {
            Console.WriteLine($"Navigating to character {characterId}");
            NavManager.NavigateTo($"/characterView/{characterId}");
        }
    }
}