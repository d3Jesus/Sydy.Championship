using AutoMapper;
using AutoMapper.Execution;
using Sydy.Championship.Application.Interfaces;
using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Championship;
using Sydy.Championship.CoreBusiness.Entities;
using Sydy.Championship.CoreBusiness.Interfaces;
using System.Linq.Expressions;

namespace Sydy.Championship.Application.Services
{
    public class ChampionshipService : IChampionshipService
    {
        private readonly IMapper _mapper;
        private readonly IChampionshipRepository _repository;

        public ChampionshipService(IMapper mapper, IChampionshipRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<string>> AddAsync(AddChampionshipViewModel championship)
        {
            var serviceResponse = new ServiceResponse<string>();
            try
            {
                var mapper = _mapper.Map<ChampionshipModel>(championship);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.Message = _mapper.Map<string>(response);
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = string.Concat("Error: ", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetChampionshipViewModel>>> GetChampionshipAsync(string name = "", int year = 0)
        {
            var result = await _repository.GetChampionshipAsync(name, year);

            var serviceResponse = new ServiceResponse<IEnumerable<GetChampionshipViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetChampionshipViewModel>>(result)
            };

            return serviceResponse;
        }
    }
}
