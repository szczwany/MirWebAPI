using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirWebAPI.Models;
using MirWebAPI.Repositories;

namespace MirWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestsController : Controller
    {
        private readonly IRepository<Quest> _questsRepository;

        public QuestsController(IRepository<Quest> questsRepository)
        {
            _questsRepository = questsRepository;
        }

        // GET api/quests
        [HttpGet]
        public async Task<IActionResult> GetQuests()
        {
            var quests = await _questsRepository.GetAll();

            return Ok(quests);
        }

        // GET api/quests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuest(int id)
        {
            var quests = await _questsRepository.GetById(id);

            return Ok(quests);
        }
    }
}