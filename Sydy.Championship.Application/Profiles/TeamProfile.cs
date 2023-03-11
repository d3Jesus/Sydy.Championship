using AutoMapper;
using Sydy.Championship.Application.ViewModels.Teams;
using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.Application.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, GetTeamViewModel>();
            CreateMap<GetTeamViewModel, Team>();

            CreateMap<Team, AddTeamViewModel>();
            CreateMap<AddTeamViewModel, Team>();
        }
    }
}
