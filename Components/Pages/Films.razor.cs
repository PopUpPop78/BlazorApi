using BlazorApi.DataServices;
using BlazorApi.Dtos.Films;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components.Pages
{
    public partial class Films
    {
        [Inject]
        public IFilmsDataService FilmsDataService { get; set; }

        private IEnumerable<Film> films;

        protected override async Task OnInitializedAsync()
        {
            var dto = await FilmsDataService.GetFilmsInfo();

            if(dto != null)
                films = dto.Data.AllFilms.Films;
        }
    }
}