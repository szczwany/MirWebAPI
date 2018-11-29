using Microsoft.EntityFrameworkCore;
using MirWebAPI.Data;
using MirWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirWebAPI.Repositories
{
    public class SkillsRepository : IRepository<Skill>
    {
        private readonly DataContext _dataContext;

        public SkillsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
            var skills = await _dataContext.Skills.Include(r => r.Role).ToListAsync();

            return skills;
        }

        public async Task<Skill> GetById(int id)
        {
            var skill = await _dataContext.Skills.FirstOrDefaultAsync(s => s.Id == id);

            return skill;
        }
    }
}
