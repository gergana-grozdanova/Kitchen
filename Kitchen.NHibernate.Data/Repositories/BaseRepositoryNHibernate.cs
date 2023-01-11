using Kitchen.Abstraction.Data;
using Kitchen.Models;
using Kitchen.NHibernate.Data.Config;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.NHibernate.Data.Repositories
{
   public class BaseRepositoryNHibernate<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ISessionFactory _sessionFactory;
        public BaseRepositoryNHibernate()
        {
            _sessionFactory = NHibernateConfiguration.Configure().BuildSessionFactory()
;        }
        public void Create(TEntity entity)
        {
            using(var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Save(entity);
                tx.Commit();             
            }
        }

        public void Delete(string id)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var obj = session.Load<TEntity>(id);
                 session.Delete(obj);               
                
            }
        }

        public void Delete(TEntity entityToDelete)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Delete(entityToDelete);

            }
        }

        public void Dispose()
        {
//In general NHibernate won't keep open connection to DB longer then it needs to. It uses SQL Server connection pool to get connections quickly and return them. So in terms of open connection its not a problem not to dispose a session.
//But session also keeps track of all changes in entities and flushes them in DB on dispose / commit transaction
        }


        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                return await session.Query<TEntity>().Where(expression).ToListAsync();
            }
        }

        public async Task<TEntity> GetById(string id)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                return await session.GetAsync<TEntity>(id);
               
            }
        }

        public void Save()
        {
            //using (var session = _sessionFactory.OpenSession())
            //using (var tx = session.BeginTransaction())
            //{

            //    tx.Commit();
            //}
        }

        public void Update(TEntity entity)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                 session.Update(entity);

            }
        }
    }
}

