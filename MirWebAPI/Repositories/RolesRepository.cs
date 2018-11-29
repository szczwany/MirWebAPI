using Microsoft.EntityFrameworkCore;
using MirWebAPI.Data;
using MirWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirWebAPI.Repositories
{
    public class RolesRepository : IRepository<Role>
    {
        private readonly DataContext _dataContext;

        public RolesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            var roles = await _dataContext.Roles.ToListAsync();

            return roles;
        }

        public async Task<Role> GetById(int id)
        {
            var role = await _dataContext.Roles.FirstOrDefaultAsync(r => r.Id == id);

            return role;
        }
    }
}
