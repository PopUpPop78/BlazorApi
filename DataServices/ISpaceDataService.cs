using BlazorApi.Dtos.Space;

namespace BlazorApi.DataServices
{
    public interface ISpaceDataService
    {
        Task<SpaceAgenciesDto> GetSpaceAgencies();
    }
}