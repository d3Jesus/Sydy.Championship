using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Championship;

namespace Sydy.Championship.Application.Interfaces
{
    public interface IChampionshipService
    {
        Task<ServiceResponse<IEnumerable<GetChampionshipViewModel>>> GetChampionshipAsync();
        Task<ServiceResponse<AddChampionshipViewModel>> AddAsync(AddChampionshipViewModel championship);
    }
}
