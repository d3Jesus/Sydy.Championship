using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sydy.Championship.Application.Interfaces;
using Sydy.Championship.Application.Services;
using Sydy.Championship.CoreBusiness.Interfaces;
using Sydy.Championship.Infrastructure.Data;
using Sydy.Championship.Infrastructure.Repositories;

namespace Sydy.Championship.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddDbContext<ChampionshipDbContext>(options => options.UseSqlServer(
                Environment.GetEnvironmentVariable("ConnectionStrings:Championship")));

            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamService, TeamService>();

            return services;
        }
    }
}
