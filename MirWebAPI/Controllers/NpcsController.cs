using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirWebAPI.Models;
using MirWebAPI.Repositories;

namespace MirWebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NpcsController : Controller
    {
        private readonly IRepository<Npc> _npcsRepository;

        public NpcsController(IRepository<Npc> npcsRepository)
        {
            _npcsRepository = npcsRepository;
        }

        // GET api/npcs
        [HttpGet]
        public async Task<IActionResult> GetNpcs()
        {
            var npcs = await _npcsRepository.GetAll();

            return Ok(npcs);
        }

        // GET api/npcs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNpc(int id)
        {
            var npc = await _npcsRepository.GetById(id);

            return Ok(npc);
        }
    }
}