using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Championship;
using Sydy.Championship.CoreBusiness.Entities;
using System.Linq.Expressions;

namespace Sydy.Championship.Application.Interfaces
{
    public interface IChampionshipService
    {
        Task<ServiceResponse<IEnumerable<GetChampionshipViewModel>>> GetChampionshipAsync(string name = "", int year = 0);
        //Task<ServiceResponse<IEnumerable<GetChampionshipViewModel>>> GetChampionshipByNameAsync(Expression<Func<GetChampionshipViewModel, bool>> func);
        Task<ServiceResponse<string>> AddAsync(AddChampionshipViewModel championship);
    }
}
