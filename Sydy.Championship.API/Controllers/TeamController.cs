using Microsoft.AspNetCore.Mvc;
using Sydy.Championship.Application.Interfaces;

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
    }
}
