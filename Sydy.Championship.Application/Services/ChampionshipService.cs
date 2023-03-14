using AutoMapper;
using Sydy.Championship.Application.Interfaces;
using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Championship;
using Sydy.Championship.Application.ViewModels.Teams;
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

        public async Task<QueryStringParameter<GetChampionshipViewModel>> GetPaginatedAsync (int pageNumber, int itemsPerPage)
        {
            var championship = await this.GetChampionshipAsync();

            var pageCount = Math.Ceiling(championship.ResponseData.Count() / (decimal)itemsPerPage);

            championship.ResponseData = championship.ResponseData.Skip((pageNumber - 1) * itemsPerPage)
                .Take((int)itemsPerPage)
                .ToList();

            var response = new QueryStringParameter<GetChampionshipViewModel>
            {
                PageNumber = pageNumber,
                ItemsPerPage = itemsPerPage,
                TotalPages = (int)pageCount,
                Items = championship.ResponseData
            };

            return response;
        }
    }
}
