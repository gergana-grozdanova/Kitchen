using AutoMapper;
using Kitchen.Abstraction.Data;
using Kitchen.Abstraction.Services.Interfaces;
using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Abstraction.Services
{
    class ReadService<TEntity, TDto> : IReadService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
    {
        private readonly IReadable<TEntity> _repo;
        private readonly IMapper _mapper;
        public ReadService(IReadable<TEntity> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            var all = await _repo.GetAll(expression);
            return all.Select(e => (_mapper.Map<TDto>(e)));
        }

        public async Task<TDto> GetById(string id)
        {
            return _mapper.Map<TDto>(await _repo.GetById(id));
        }
    }
}
