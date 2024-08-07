using Microsoft.AspNetCore.Mvc;
using MysticExpeditions.Domain.Data.Repositories.Interfaces;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RacesController : ControllerBase
    {
        private readonly IRaceRepository _raceRepository;

        public RacesController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetRaces()
        {
            return await _raceRepository.GetRacesAsync();
        }
    }
}