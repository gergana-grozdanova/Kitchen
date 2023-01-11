using AutoMapper;
using Kitchen.Abstraction.Data;
using Kitchen.Models;
using Kitchen.Services.Abstraction;
using Kitchen.Services.Dtos;
using Kitchen.UoW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services
{
    public class BaseService<TEntity,TDto>:IBaseService<TEntity,TDto>
        where TEntity:BaseEntity
        where TDto:BaseDto
        
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IMapper _mapper;
        private IUnitOfWork unitOfWork;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public void Create(TEntity entity)
        {
            _baseRepository.Create(entity);
            unitOfWork.Save();
        }

        public void Delete(string id)
        {
            _baseRepository.Delete(id);
            unitOfWork.Save();
        }

      
       
        public async Task<TDto> GetById(string id)
        {
            return _mapper.Map<TDto>(await _baseRepository.GetById(id));
        }

        public async void Update(TEntity entity)
        {
            var ent = await _baseRepository.GetById(entity.Id);
            ent = entity;
            unitOfWork.Save();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    unitOfWork.RollBack();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            var all = await _baseRepository.GetAll(expression);
            return all.Select(e => (_mapper.Map<TDto>(e)));
        }
    }
}
