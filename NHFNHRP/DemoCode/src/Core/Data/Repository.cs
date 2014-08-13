using System.Collections.Generic;
using System.Linq;

namespace Core.Data
{
    public interface Repository
    {
        IQueryable<T> All<T>();
        void Save<T>(T item);
        void SaveList<T>(IList<T> items);
        void Delete<T>(T item);
        void Delete<T>(int id);
    }
}