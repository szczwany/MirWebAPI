using Microsoft.EntityFrameworkCore;
using MirWebAPI.Data;
using MirWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirWebAPI.Repositories
{
    public class NpcsRepository : IRepository<Npc>
    {
        private readonly DataContext _dataContext;

        public NpcsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Npc>> GetAll()
        {
            var npcs = await _dataContext.Npcs.ToListAsync();

            return npcs;
        }

        public async Task<Npc> GetById(int id)
        {
            var npc = await _dataContext.Npcs.FirstOrDefaultAsync(m => m.Id == id);

            return npc;
        }
    }
}
