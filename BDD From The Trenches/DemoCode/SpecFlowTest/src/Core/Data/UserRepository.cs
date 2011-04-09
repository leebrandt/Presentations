using SFT.Core.Domain.Authentication;

namespace SFT.Core.Data
{
    public interface UserRepository
    {
        User GetByUsername(string username);
    }
}