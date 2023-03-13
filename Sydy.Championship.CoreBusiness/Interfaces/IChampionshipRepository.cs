using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.CoreBusiness.Interfaces
{
    public interface IChampionshipRepository
    {
        Task<IEnumerable<ChampionshipModel>> GetChampionshipAsync();
        Task<ChampionshipModel> AddAsync(ChampionshipModel championship);
    }
}
