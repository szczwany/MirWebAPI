using Microsoft.EntityFrameworkCore;
using MirWebAPI.Data;
using MirWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirWebAPI.Repositories
{
    public class FloorsRepository : IRepository<Floor>
    {
        private readonly DataContext _dataContext;

        public FloorsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Floor>> GetAll()
        {
            var floors = await _dataContext.Floors.ToListAsync();

            return floors;
        }

        public async Task<Floor> GetById(int id)
        {
            var floor = await _dataContext.Floors.FirstOrDefaultAsync(f => f.Id == id);

            return floor;
        }
    }
}
