using AutoMapper;
using Sydy.Championship.Application.Interfaces;
using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Championship;
using Sydy.Championship.CoreBusiness.Entities;
using Sydy.Championship.CoreBusiness.Interfaces;

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

        public async Task<ServiceResponse<AddChampionshipViewModel>> AddAsync(AddChampionshipViewModel championship)
        {
            var serviceResponse = new ServiceResponse<AddChampionshipViewModel>();
            try
            {
                var mapper = _mapper.Map<ChampionshipModel>(championship);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<AddChampionshipViewModel>(response);
                serviceResponse.Message = $"Championship with name {championship.Name} added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetChampionshipViewModel>>> GetChampionshipAsync()
        {
            var result = await _repository.GetChampionshipAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetChampionshipViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetChampionshipViewModel>>(result)
            };

            return serviceResponse;
        }
    }
}
