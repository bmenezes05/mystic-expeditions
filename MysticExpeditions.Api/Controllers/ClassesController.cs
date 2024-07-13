using Microsoft.AspNetCore.Mvc;
using MysticExpeditions.Domain.Data.Repositories.Interfaces;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassRepository _classRepository;

        public ClassesController(IClassRepository classRepository)
        {            
            _classRepository = classRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            return await _classRepository.GetClassesAsync();
        }

        [HttpGet("subclasses")]
        public async Task<ActionResult<IEnumerable<Class>>> GetSubclasses()
        {
            return await _classRepository.GetSubclassesAsync();
        }
    }
}