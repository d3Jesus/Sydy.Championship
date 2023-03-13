using Microsoft.AspNetCore.Mvc;
using Sydy.Championship.Application.Interfaces;

namespace Sydy.Championship.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly IChampionshipService _service;

        public ChampionshipController(IChampionshipService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetChampionshipAsync());
        }
    }
}
