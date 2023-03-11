using AutoMapper;
using Sydy.Championship.Application.Interfaces;
using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Teams;
using Sydy.Championship.CoreBusiness.Interfaces;

namespace Sydy.Championship.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;

        public TeamService(IMapper mapper, ITeamRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<IEnumerable<GetTeamViewModel>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetTeamViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetTeamViewModel>>(result)
            };

            return serviceResponse;
        }
    }
}
