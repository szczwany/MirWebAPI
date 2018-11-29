using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirWebAPI.Models;
using MirWebAPI.Repositories;

namespace MirWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        private readonly IRepository<Skill> _skillsRepository;

        public SkillsController(IRepository<Skill> skillsRepository)
        {
            _skillsRepository = skillsRepository;
        }

        // GET api/skills
        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            var skills = await _skillsRepository.GetAll();

            return Ok(skills);
        }

        // GET api/skills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkill(int id)
        {
             var skill = await _skillsRepository.GetById(id);

             return Ok(skill);        
        }
    }
}