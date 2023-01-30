using Kitchen.Abstraction.Data;
using Kitchen.Abstraction.Services.Interfaces;
using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Abstraction.Services
{
    public abstract class CreateService<TEntity> : ICreateService<TEntity> where TEntity:BaseEntity
    {
        private readonly ICreatable<TEntity> _repository;
        public CreateService(ICreatable<TEntity> repository)
        {
            _repository = repository;
        }
        public void Create(TEntity entity)
        {
            _repository.Create(entity);
        }
    }
}
