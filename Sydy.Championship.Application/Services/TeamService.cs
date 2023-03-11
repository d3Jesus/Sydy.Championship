using AutoMapper;
using Sydy.Championship.Application.Interfaces;
using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Teams;
using Sydy.Championship.CoreBusiness.Entities;
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

        public async Task<ServiceResponse<GetTeamViewModel>> AddAsync(AddTeamViewModel team)
        {
            var serviceResponse = new ServiceResponse<GetTeamViewModel>();
            try
            {
                var mapper = _mapper.Map<Team>(team);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetTeamViewModel>(response);
                serviceResponse.Message = $"Team with name {team.Name} added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
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
