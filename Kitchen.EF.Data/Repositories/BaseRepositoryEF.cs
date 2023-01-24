using Kitchen.Abstraction.Data;
using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.EF.Data.Repositories
{
    public class BaseRepositoryEF<TEntity> : IBaseRepository<TEntity>
         where TEntity : BaseEntity
    {
        //TODO: fix thissss
        private readonly IReadable<TEntity> _readRepo;
        private readonly IDeletable<TEntity> _deleteRepo;
        private readonly ICreatable<TEntity> _createRepo;
        public BaseRepositoryEF(IReadable<TEntity> readRepo,IDeletable<TEntity> deleteRepo,ICreatable<TEntity> createRepo)
        {
            _readRepo = readRepo;
            _deleteRepo = deleteRepo;
            _createRepo = createRepo;
        }
        public void Create(TEntity entity)
        {
            _createRepo.Create(entity);
        }

        public void Delete(string id)
        {
            _deleteRepo.Delete(id);
        }

        public void Delete(TEntity entityToDelete)
        {
            _deleteRepo.Delete(entityToDelete);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return await _readRepo.GetAll(expression);
        }

        public async Task<TEntity> GetById(string id)
        {
           return await _readRepo.GetById(id);
        }
    }
}
