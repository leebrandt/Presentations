using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Core.Data.NHibernate
{
    public class NHibernateRepository : Repository
    {
        readonly ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> All<T>()
        {
            return _session.Query<T>();
        }

        public void Save<T>(T item)
        {
            using (var tnx = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(item);
                    tnx.Commit();
                }
                catch (Exception)
                {
                    tnx.Rollback();
                    throw;
                }
            }
        }

        public void SaveList<T>(IList<T> items)
        {
            using (var tnx = _session.BeginTransaction())
            {
                try
                {
                    items.ToList().ForEach(x => _session.SaveOrUpdate(x));
                    tnx.Commit();
                }
                catch (Exception)
                {
                    tnx.Rollback();
                    throw;
                }
            }
        }

        public void Delete<T>(T item)
        {
            using (var tnx = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(item);
                    tnx.Commit();
                }
                catch (Exception)
                {
                    tnx.Rollback();
                    throw;
                }
            }
        }

        public void Delete<T>(int id)
        {
            Delete(_session.Get<T>(id));
        }

    }
}