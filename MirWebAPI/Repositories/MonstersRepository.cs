using Microsoft.EntityFrameworkCore;
using MirWebAPI.Data;
using MirWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirWebAPI.Repositories
{
    public class MonstersRepository : IRepository<Monster>
    {
        private readonly DataContext _dataContext;

        public MonstersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Monster>> GetAll()
        {
            var monsters = await _dataContext.Monsters.ToListAsync();

            return monsters;
        }

        public async Task<Monster> GetById(int id)
        {
            var monster = await _dataContext.Monsters.FirstOrDefaultAsync(m => m.Id == id);

            return monster;
        }
    }
}
