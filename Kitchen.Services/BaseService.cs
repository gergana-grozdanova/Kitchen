using AutoMapper;
using Kitchen.Data;
using Kitchen.Data.Entities;
using Kitchen.Data.Repositories;
using Kitchen.Services.Abstraction;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services
{
    public class BaseService<TEntity,TDto>:IBaseService<TEntity,TDto>,IDisposable
        where TEntity:BaseEntity
        where TDto:BaseDto
        
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public void Create(TEntity entity)
        {
            _baseRepository.Create(entity);
            _baseRepository.Save();
        }

        public void Delete(string id)
        {
             _baseRepository.Delete(id);
            _baseRepository.Save();
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            var all = await _baseRepository.GetAll();
            return all.Select(e=>(_mapper.Map<TDto>(e) ));
        }

       
        public async Task<TDto> GetById(string id)
        {
            return _mapper.Map<TDto>(await _baseRepository.GetById(id));
        }

        public void Update(TEntity entity)
        {
            _baseRepository.Update(entity);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _baseRepository.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
