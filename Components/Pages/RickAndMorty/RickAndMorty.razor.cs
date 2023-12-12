using BlazorApi.DataServices;
using BlazorApi.Dtos.RickAndMorty;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

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
        [Parameter]
        public string FilterText {get;set;}
        
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
            filterText = FilterText ?? filterText;

            await GetCharactersAndInfo();
            
            MinMaxDisabled();
        }

        private async Task GetCharactersAndInfo()
        {
            var charactersDto = await RickAndMortyDataService.GetAllCharacters(activePage, filterText);

            if(charactersDto != null)
                UpdateCharacters(charactersDto.Data.CharactersInfo);

            if(activePage > totalPages)
            {
                activePage = 1;
                charactersDto = await RickAndMortyDataService.GetAllCharacters(activePage, filterText);
                
                if(charactersDto != null)
                    UpdateCharacters(charactersDto.Data.CharactersInfo);
            }

            NavManager.NavigateTo($"/rickandmorty/{activePage}/{minPageView}/{filterText}");
        }

        private void UpdateCharacters(CharactersInfo characterInfo)
        {
            characters = characterInfo.Characters;
            totalPages = characterInfo.Info.Pages ?? 0;
            totalCharacters = characterInfo.Info.Count ?? 0;   
                            
            MinMaxDisabled();         
        }

        private void IncrementPageView()
        {
            if(minPageView + maxPagesView > totalPages)
                return;

            minPageView = Math.Min(minPageView + 5, totalPages - 5);
            MinMaxDisabled();
            NavManager.NavigateTo($"/rickandmorty/{activePage}/{minPageView}/{filterText}");
        }

        private void DecrementPageView()
        {
            if(minPageView == 1)
                return;

            minPageView = Math.Max(minPageView -5 , 1);
            MinMaxDisabled();
            NavManager.NavigateTo($"/rickandmorty/{activePage}/{minPageView}/{filterText}"); 
        }

        private void MinMaxDisabled()
        {
            IsMinDisabled = minPageView == 1 ? disabled : "";
            IsMaxDisabled = minPageView + maxPagesView >= totalPages ? disabled : "";            
        }

        private string IsActive(int item)
        {
            return item == activePage ? active : ""; 
        }

        private void SetActive(int item)
        {
            activePage = item;
            NavManager.NavigateTo($"/rickandmorty/{activePage}/{minPageView}/{filterText}");
        }

        private void ViewCharacter(string id)
        {
            Console.WriteLine($"Navigating to character {id}");
            NavManager.NavigateTo($"/characterView/{id}");
        }

        private void InputKeyPress(KeyboardEventArgs e)
        {
            if(e.Code == "Enter")
                _ = GetCharactersAndInfo(); 
        }
    }
}