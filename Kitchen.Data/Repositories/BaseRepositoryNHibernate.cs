using Kitchen.Data.Config;
using Kitchen.Data.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Data.Repositories
{
   public class BaseRepositoryNHibernate<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ISessionFactory _sessionFactory;
        public BaseRepositoryNHibernate()
        {
            _sessionFactory = NHibernateConfiguration.Configure().BuildSessionFactory()
;        }
        public async Task<TEntity> Create(TEntity entity)
        {
            using(var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
               await session.SaveAsync(entity);
                tx.Commit();
                return entity;
            }
        }

        public async Task Delete(string id)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var obj = session.Load<TEntity>(id);
                await session.DeleteAsync(obj);               
                
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
             return await session.Query<TEntity>().ToListAsync();            
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

        public async Task<TEntity> Update(TEntity entity)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                await session.UpdateAsync(entity);
                return entity;

            }
        }
    }
}

