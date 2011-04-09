using System.Linq;

namespace SFT.Core.Data
{
    public interface Repository
    {
        IQueryable<T> All<T>();
        void Save<T>(T item);
    }
}