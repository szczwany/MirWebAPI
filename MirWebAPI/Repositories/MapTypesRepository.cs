using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MirWebAPI.Data;
using MirWebAPI.Models;

namespace MirWebAPI.Repositories
{
    public class MapTypesRepository : IMapTypesRepository
    {
        private readonly DataContext _dataContext;

        public MapTypesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<MapType>> GetMapTypes()
        {
            var maps = await _dataContext.MapTypes.Include(m => m.Maps)
                                                    .ToListAsync();

            return maps;
        }

        public async Task<MapType> GetById(int id)
        {
            var mapType = await _dataContext.MapTypes.Include(m => m.Maps)
                                                    .FirstOrDefaultAsync(m => m.Id == id);

            return mapType;
        }

        public async Task<IEnumerable<MapType>> GetSpecificType(string type)
        {
            var maps = await _dataContext.MapTypes.Include(m => m.Maps)
                                                    .Where(x => x.Description.Equals(type))
                                                    .ToListAsync();

            return maps;
        }
    }
}
