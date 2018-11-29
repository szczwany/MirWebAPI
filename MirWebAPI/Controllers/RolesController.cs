using Microsoft.AspNetCore.Mvc;
using MirWebAPI.Models;
using MirWebAPI.Repositories;
using System.Threading.Tasks;

namespace MirWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRepository<Role> _rolesRepository;

        public RolesController(IRepository<Role> rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        // GET api/roles
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _rolesRepository.GetAll();

            return Ok(roles);
        }

        // GET api/roles/4
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var role = await _rolesRepository.GetById(id);

            return Ok(role);
        }
    }
}
