using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace SFT.Core.Data.NHibernate
{
    public class NHibernateRepository : Repository
    {
        readonly ISessionFactory _sessionFactory;

        public NHibernateRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IQueryable<TType> All<TType>()
        {
            var session = _sessionFactory.OpenSession();
            return session.Query<TType>();
        }

        public void Save<T>(T item)
        {
            using(var session = _sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(item);
            }
        }
    }
}