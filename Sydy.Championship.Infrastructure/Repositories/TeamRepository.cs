using Microsoft.EntityFrameworkCore;
using Sydy.Championship.CoreBusiness.Entities;
using Sydy.Championship.CoreBusiness.Interfaces;
using Sydy.Championship.Infrastructure.Data;

namespace Sydy.Championship.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ChampionshipDbContext _context;

        public TeamRepository(ChampionshipDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAsync()
        {
            return await _context.Teams.ToListAsync();
        }
    }
}
