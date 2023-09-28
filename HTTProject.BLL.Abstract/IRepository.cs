using HTTProject.Entities;

namespace HTTProject.BLL.Abstract
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> GetByName(string Name);
    }
}