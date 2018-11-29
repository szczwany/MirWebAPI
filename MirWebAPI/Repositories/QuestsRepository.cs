using Microsoft.EntityFrameworkCore;
using MirWebAPI.Data;
using MirWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirWebAPI.Repositories
{
    public class QuestsRepository : IRepository<Quest>
    {
        private readonly DataContext _dataContext;

        public QuestsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Quest>> GetAll()
        {
            var quests = await _dataContext.Quests.ToListAsync();

            return quests;
        }

        public async Task<Quest> GetById(int id)
        {
            var quest = await _dataContext.Quests.FirstOrDefaultAsync(q => q.Id == id);

            return quest;
        }
    }
}
