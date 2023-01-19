using Kitchen.Logging;
using Kitchen.Models;
using Kitchen.Services.Abstraction;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services.Decorators
{
  public class ExceptionLoggingBaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
         where TEntity : BaseEntity
        where TDto : BaseDto
    {
        private readonly IBaseService<TEntity, TDto> _wrappedService;
        private readonly ILogger _logger;
        public ExceptionLoggingBaseService(IBaseService<TEntity,TDto> wrappedService,ILogger logger)
        {
            _wrappedService = wrappedService;
            _logger = logger;
        }
        public void Create(TEntity entity)
        {
            try
            {
                _wrappedService.Create(entity);
            }
            catch (Exception ex)
            {
                 _logger.LogException(ex).GetAwaiter();
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                _wrappedService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex).GetAwaiter();
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                _wrappedService.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex).GetAwaiter();
                throw;
            }
        }

        public Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
               return _wrappedService.GetAll(x=>x==x);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex).GetAwaiter();
                throw;
            }
        }

        public Task<TDto> GetById(string id)
        {
            try
            {
              return  _wrappedService.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex).GetAwaiter();
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _wrappedService.Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex).GetAwaiter();
                throw;
            }
        }
    }
}
