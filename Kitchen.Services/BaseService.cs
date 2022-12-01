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
    public class BaseService<TEntity,TDto>:IBaseService<TEntity,TDto> 
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

        public async Task<TDto> Create(TEntity entity)
        {
          return  _mapper.Map<TDto>(await _baseRepository.Create(entity));
        }

        public async Task Delete(string id)
        {
            await _baseRepository.Delete(id);
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

        public async Task<TDto> Update(TEntity entity)
        {
            return _mapper.Map<TDto>(await _baseRepository.Update(entity));
        }
    }
}
