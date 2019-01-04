using ApacheCassandra.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ApacheCassandra.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> Fetch();
        void Insert(TEntity entity);
        TEntity FirstOrDefault(Guid id);
        void Delete(Guid id);
    }
}
