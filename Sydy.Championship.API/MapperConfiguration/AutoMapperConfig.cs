using Sydy.Championship.Application.Profiles;

namespace Sydy.Championship.API.MapperConfiguration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(TeamProfile));
        }
    }
}
