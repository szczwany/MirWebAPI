using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MirWebAPI.Data;
using MirWebAPI.Models;

namespace MirWebAPI.Repositories
{
    public class MapsRepository : IRepository<Map>
    {
        private readonly DataContext _dataContext;

        public MapsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Map>> GetAll()
        {
            var maps = await _dataContext.Maps.Include(f => f.Floors)
                                                .ToListAsync();

            return maps;
        }

        public async Task<Map> GetById(int id)
        {
            var map = await _dataContext.Maps.Include(m => m.Monsters)
                                             .Include(n => n.Npcs)
                                             .Include(f => f.Floors)
                                                .FirstOrDefaultAsync(m => m.Id == id);

            return map;
        }
    }
}
