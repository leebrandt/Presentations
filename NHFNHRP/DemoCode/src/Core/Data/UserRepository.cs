using Core.Domain;

namespace Core.Data
{
    public interface UserRepository
    {
        User GetByUsername(string username);
    }
}