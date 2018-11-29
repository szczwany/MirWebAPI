using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirWebAPI.Models;
using MirWebAPI.Repositories;

namespace MirWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FloorsController : Controller
    {
        private readonly IRepository<Floor> _floorsRepository;

        public FloorsController(IRepository<Floor> floorsRepository)
        {
            _floorsRepository = floorsRepository;
        }

        // GET api/floors
        [HttpGet]
        public async Task<IActionResult> GetFloors()
        {
            var floors = await _floorsRepository.GetAll();

            return Ok(floors);
        }

        // GET api/floors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFloor(int id)
        {
            var floor = await _floorsRepository.GetById(id);

            return Ok(floor);
        }
    }
}