using Microsoft.EntityFrameworkCore;
using Sydy.Championship.CoreBusiness.Entities;
using Sydy.Championship.CoreBusiness.Interfaces;
using Sydy.Championship.Infrastructure.Data;

namespace Sydy.Championship.Infrastructure.Repositories
{
    public class ChampionshipRepository : IChampionshipRepository
    {
        private readonly ChampionshipDbContext _context;

        public ChampionshipRepository(ChampionshipDbContext context)
        {
            _context = context;
        }
        public Task<ChampionshipModel> AddAsync(ChampionshipModel championship)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ChampionshipModel>> GetChampionshipAsync()
        {
            return await _context.Championships
                .Include(x => x.Matches)
                .Select(x => new ChampionshipModel
                {
                    Name = x.Name,
                    Year = x.Year,
                    Champion = string.IsNullOrEmpty(x.Champion) ? "NOT AVAILABLE" : x.Champion,
                    Vice = string.IsNullOrEmpty(x.Vice) ? "NOT AVAILABLE" : x.Vice,
                    ThirdPlace = string.IsNullOrEmpty(x.ThirdPlace) ? "NOT AVAILABLE" : x.ThirdPlace,
                    MatchesResult = x.MatchesResult
                })
                .ToListAsync();
        }
    }
}
