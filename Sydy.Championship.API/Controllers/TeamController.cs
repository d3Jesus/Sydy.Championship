using Microsoft.AspNetCore.Mvc;
using Sydy.Championship.Application.Interfaces;
using Sydy.Championship.Application.ViewModels.Teams;

namespace Sydy.Championship.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpGet("{pageNumber}/{itemsPerPage}")]
        public async Task<IActionResult> GetAll(int pageNumber, int itemsPerPage)
        {
            return Ok(await _service.GetPaginatedAsync(pageNumber, itemsPerPage));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTeamViewModel model)
        {
            var exitingTeam = await _service.GetByNameAsync(model.Name);

            if (exitingTeam.ResponseData is not null)
            {
                exitingTeam.Message = $"There is a team with name {model.Name}.";
                return Ok(exitingTeam);
            }

            var response = await _service.AddAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetTeamViewModel model)
        {
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTeam = await _service.GetByIdAsync(id);

            if (existingTeam is null) 
                return NotFound();

            var response = await _service.DeleteAsync(existingTeam.ResponseData);

            return Ok(response);
        }
    }
}
