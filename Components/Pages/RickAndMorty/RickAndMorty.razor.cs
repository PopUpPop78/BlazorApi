using BlazorApi.DataServices;
using BlazorApi.Dtos.RickAndMorty;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components.Pages.RickAndMorty
{
    public partial class RickAndMorty
    {
        [Inject]
        public IRickAndMortyDataService RickAndMortyDataService {get;set;}
        [Inject]
        public NavigationManager NavManager {get;set;}

        [Parameter]
        public int? ActivePage {get;set;}
        [Parameter]
        public int? MinPageView {get;set;}
        
        private const string disabled = "disabled";
        private const string active = "active";

        private IEnumerable<CharacterInfo> characters;

        private int totalPages;
        private int totalCharacters;
        private int maxPagesView = 5;
        private string filterText = string.Empty;
        private string IsMinDisabled = disabled;
        private string IsMaxDisabled = "";
        private int activePage = 1;
        private int minPageView = 1;

        protected async override Task OnInitializedAsync()
        {
            activePage = ActivePage ?? activePage;
            minPageView = MinPageView ?? minPageView;
            await GetCharactersAndInfo();
        }

        private async Task GetCharactersAndInfo()
        {
            var charactersDto = await RickAndMortyDataService.GetAllCharacters(activePage, filterText);

            if(charactersDto != null)
            {
                characters = charactersDto.Data.CharactersInfo.Characters;
                totalPages = charactersDto.Data.CharactersInfo.Info.Pages;
                totalCharacters = charactersDto.Data.CharactersInfo.Info.Count;
            }
        }

        private void IncrementPageView()
        {
            if(minPageView + maxPagesView > totalPages)
                return;

            minPageView++;
            IsMaxDisabled = minPageView + maxPagesView > totalPages ? disabled : "";
            IsMinDisabled = minPageView == 1 ? disabled : "";
            NavManager.NavigateTo($"/rickandmorty/{activePage}");
        }

        private void DecrementPageView()
        {
            if(minPageView == 1)
                return;

            minPageView--;
            IsMinDisabled = minPageView == 1 ? disabled : "";
            IsMaxDisabled = minPageView + maxPagesView > totalPages ? disabled : "";
            NavManager.NavigateTo($"/rickandmorty/{activePage}/{minPageView}");            
        }

        private string IsActive(int item)
        {
            return item == activePage ? active : ""; 
        }

        private void SetActive(int item)
        {
            activePage = item;
            NavManager.NavigateTo($"/rickandmorty/{activePage}/{minPageView}");
        }

        private void ViewCharacter(string id)
        {
            Console.WriteLine($"Navigating to character {id}");
            NavManager.NavigateTo($"/characterView/{id}");
        }
    }
}