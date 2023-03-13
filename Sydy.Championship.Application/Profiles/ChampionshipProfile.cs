using AutoMapper;
using Sydy.Championship.Application.ViewModels.Championship;
using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.Application.Profiles
{
    public class ChampionshipProfile : Profile
    {
        public ChampionshipProfile()
        {
            //CreateMap<ChampionshipModel, AddChampionshipViewModel>();
            //CreateMap<AddChampionshipViewModel, ChampionshipModel>();

            //CreateMap<MatchModel, AddMatchViewModel>();
            //CreateMap<AddMatchViewModel, MatchModel>();

            CreateMap<ChampionshipModel, GetChampionshipViewModel>();
            CreateMap<GetChampionshipViewModel, ChampionshipModel>();

            CreateMap<VwMatchResultsModel, GetVwMatchResultsViewModel>();
            CreateMap<GetVwMatchResultsViewModel, VwMatchResultsModel>();
        }
    }
}