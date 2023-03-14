using Microsoft.AspNetCore.Mvc;
using Sydy.Championship.Application.Interfaces;
using Sydy.Championship.Application.ViewModels.Championship;
using Sydy.Championship.CoreBusiness.Entities;
using System.Linq.Expressions;

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

        [HttpGet("{championshipName:alpha}")]
        public async Task<IActionResult> Get(string championshipName)
        {
            return Ok(await _service.GetChampionshipAsync(championshipName));
        }

        [HttpGet("{championshipYear:int}")]
        public async Task<IActionResult> Get(int championshipYear)
        {
            return Ok(await _service.GetChampionshipAsync(year: championshipYear));
        }

        [HttpGet("{championshipName:alpha}/{championshipYear:int}")]
        public async Task<IActionResult> Get(string championshipName, int championshipYear)
        {
            return Ok(await _service.GetChampionshipAsync(championshipName, championshipYear));
        }

        [HttpGet("{pageNumber:int}/{itemsPerPage:int}")]
        public async Task<IActionResult> Get (int pageNumber, int itemsPerPage)
        {
            return Ok(await _service.GetPaginatedAsync(pageNumber, itemsPerPage));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddChampionshipViewModel championship)
        {
            return Ok(await _service.AddAsync(championship));
        }
    }
}
