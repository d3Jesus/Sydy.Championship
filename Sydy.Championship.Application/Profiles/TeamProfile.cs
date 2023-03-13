using AutoMapper;
using Sydy.Championship.Application.ViewModels.Teams;
using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.Application.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamModel, GetTeamViewModel>();
            CreateMap<GetTeamViewModel, TeamModel>();

            CreateMap<TeamModel, AddTeamViewModel>();
            CreateMap<AddTeamViewModel, TeamModel>();
        }
    }
}
