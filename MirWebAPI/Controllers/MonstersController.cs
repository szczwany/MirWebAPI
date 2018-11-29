using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirWebAPI.Models;
using MirWebAPI.Repositories;

namespace MirWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonstersController : Controller
    {
        private readonly IRepository<Monster>_monstersRepository;

        public MonstersController(IRepository<Monster> monstersRepository)
        {
            _monstersRepository = monstersRepository;
        }

        // GET api/monsters
        [HttpGet]
        public async Task<IActionResult> GetMonsters()
        {
            var monsters = await _monstersRepository.GetAll();

            return Ok(monsters);
        }

        // GET api/monsters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonster(int id)
        {
            var monster = await _monstersRepository.GetById(id);

            return Ok(monster);
        }
    }
}
