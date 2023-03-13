using Sydy.Championship.CoreBusiness.Entities;
using System.Linq.Expressions;

namespace Sydy.Championship.CoreBusiness.Interfaces
{
    public interface IChampionshipRepository
    {
        Task<IEnumerable<ChampionshipModel>> GetChampionshipAsync(string name = "", int year = 0);
        //Task<IEnumerable<ChampionshipModel>> GetChampionshipByNameAsync(Expression<Func<ChampionshipModel, bool>> func);
        Task<string> AddAsync(ChampionshipModel championship);
    }
}
