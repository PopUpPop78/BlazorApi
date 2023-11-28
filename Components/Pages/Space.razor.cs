using BlazorApi.DataServices;
using BlazorApi.Dtos.Space;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components.Pages
{
    public partial class Space
    {
        [Inject]
        private ISpaceDataService spaceService { get; set; }
        private SpaceAgenciesDto spaceDto;

        protected override async Task OnInitializedAsync() => spaceDto = await spaceService.GetSpaceAgencies();
    }
}