using System.Linq;
using Core.Domain;

namespace Core.Data.NHibernate
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
                .FirstOrDefault(usr=>usr.Username == username);
        }
    }
}