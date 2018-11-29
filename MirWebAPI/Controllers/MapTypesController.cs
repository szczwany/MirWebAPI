using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirWebAPI.Repositories;

namespace MirWebAPI.Controllers
{
    [Route("api/types")]
    [ApiController]
    public class MapTypesController : Controller
    {
        private readonly IMapTypesRepository _mapTypesRepository;

        public MapTypesController(IMapTypesRepository mapTypesRepository)
        {
            _mapTypesRepository = mapTypesRepository;
        }

        // GET api/types
        [HttpGet]
        public async Task<IActionResult> GetMapTypes()
        {
            var mapTypes = await _mapTypesRepository.GetMapTypes();

            return Ok(mapTypes);
        }

        // GET api/types/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMapType(int id)
        {
            var mapType = await _mapTypesRepository.GetById(id);

            return Ok(mapType);
        }

        // GET api/types/find?type=province
        [HttpGet]
        [Route("find")]
        public async Task<IActionResult> GetSpecificTypes(string type)
        {
            var mapTypes = await _mapTypesRepository.GetSpecificType(type);

            return Ok(mapTypes);
        }
    }
}