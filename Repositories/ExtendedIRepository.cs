using System.Collections.Generic;


namespace Repositories
{
    public interface ExtendedIRepository<T> where T : class
    {
        List<T> GetByFilter(string filter);
    }
}
