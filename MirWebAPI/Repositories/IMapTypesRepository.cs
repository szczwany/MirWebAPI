using MirWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirWebAPI.Repositories
{
    public interface IMapTypesRepository
    {
        Task<IEnumerable<MapType>> GetMapTypes();
        Task<MapType> GetById(int id);

        Task<IEnumerable<MapType>> GetSpecificType(string type);
    }
}
