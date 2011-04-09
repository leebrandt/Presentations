using System.Linq;
using SFT.Core.Domain.Authentication;

namespace SFT.Core.Data.NHibernate
{
    public class NHibernateUserRepository : UserRepository
    {
        readonly Repository _repository;

        public NHibernateUserRepository(Repository repository)
        {
            _repository = repository;
        }

        public User GetByUsername(string username)
        {
            return _repository.All<User>()
                .FirstOrDefault(x => x.Username == username);
        }
    }
}