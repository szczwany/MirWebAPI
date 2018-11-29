using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirWebAPI.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
