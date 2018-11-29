using System.Threading.Tasks;

namespace MirWebAPI.Data
{
    public interface IBasicRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}
