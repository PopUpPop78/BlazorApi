using BlazorApi.Dtos;

namespace BlazorApi.DataServices
{
    public interface ISpaceDataService
    {
        Task<SpaceAgenciesDto> GetSpaceAgencies();
    }
}