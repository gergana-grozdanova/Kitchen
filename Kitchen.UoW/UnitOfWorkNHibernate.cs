using Kitchen.Abstraction.Data;
using Kitchen.NHibernate.Data.Config;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.UoW
{
    class UnitOfWorkNHibernate : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        public UnitOfWorkNHibernate()
        {
            _sessionFactory = NHibernateConfiguration.Configure().BuildSessionFactory()
;
        }
        public void RollBack()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                        transaction.Rollback();                   
                }
            }
        }

        public void Save()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    transaction.Commit();
                }
            }
        }
    }
}
