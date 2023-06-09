﻿using AutoMapper;
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
                var mapper = _mapper.Map<TeamModel>(team);
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

        public async Task<ServiceResponse<bool>> DeleteAsync(GetTeamViewModel team)
        {
            var serviceResponse = new ServiceResponse<bool>();

            if (team.Id < 1)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = $"Invalid team Id.";

                return serviceResponse;
            }

            try
            {
                var mapper = _mapper.Map<TeamModel>(team);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Team deleted successfuly!";
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

        public async Task<ServiceResponse<GetTeamViewModel>> GetByIdAsync(int id)
        {
            var serviceResponse = new ServiceResponse<GetTeamViewModel>();

            if (id < 1)
            {
                serviceResponse.Message = "Invalid team Id";
                return serviceResponse;
            }

            var result = await _repository.GetByIdAsync(id);

            if (result is null)
            {
                serviceResponse.Message = $"Team with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetTeamViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTeamViewModel>> GetByNameAsync(string name)
        {
            var serviceResponse = new ServiceResponse<GetTeamViewModel>();

            if (string.IsNullOrEmpty(name))
            {
                serviceResponse.Message = "Invalid team name";
                return serviceResponse;
            }

            var result = await _repository.GetByNameAsync(name);

            if (result is null)
            {
                serviceResponse.Message = $"Team with name {name} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetTeamViewModel>(result);

            return serviceResponse;
        }

        public async Task<QueryStringParameter<GetTeamViewModel>> GetPaginatedAsync(int pageNumber, int itemsPerPage)
        {
            var teams = await this.GetAsync();

            var pageCount = Math.Ceiling(teams.ResponseData.Count() / (decimal)itemsPerPage);

            teams.ResponseData = teams.ResponseData.Skip((pageNumber - 1) * itemsPerPage)
                .Take((int)itemsPerPage)
                .ToList();

            var response = new QueryStringParameter<GetTeamViewModel>
            {
                PageNumber = pageNumber,
                ItemsPerPage = itemsPerPage,
                TotalPages = (int)pageCount,
                Items = teams.ResponseData
            };

            return response;
        }

        public async Task<ServiceResponse<GetTeamViewModel>> UpdateAsync(GetTeamViewModel team)
        {
            var serviceResponse = new ServiceResponse<GetTeamViewModel>();

            try
            {
                var mappedAuthor = _mapper.Map<TeamModel>(team);
                var result = await _repository.UpdateAsync(mappedAuthor);

                serviceResponse.ResponseData = _mapper.Map<GetTeamViewModel>(result);
                serviceResponse.Message = "Team updated!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
