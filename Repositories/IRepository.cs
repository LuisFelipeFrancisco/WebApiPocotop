using System.Collections.Generic;

namespace Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> Get();
        T GetById(int id);
        void Add(T entity);
        int Update(int id, T entity);
        int Delete(int id);
        List<T> GetByQuery(string query);
    }
}
