using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirWebAPI.Models;
using MirWebAPI.Repositories;

namespace MirWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : Controller
    {
        private readonly IRepository<Map> _mapsRepository;

        public MapsController(IRepository<Map> mapsRepository)
        {
            _mapsRepository = mapsRepository;
        }
        
        // GET api/maps
        [HttpGet]
        public async Task<IActionResult> GetMaps()
        {
            var maps = await _mapsRepository.GetAll();

            return Ok(maps);
        }

        // GET api/maps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMap(int id)
        {
            var map = await _mapsRepository.GetById(id);

            return Ok(map);
        }
    }
}