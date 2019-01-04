using ApacheCassandra.Domain.Entities;
using ApacheCassandra.Domain.Interfaces.Repositories;
using Cassandra;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;


namespace ApacheCassandra.Infra.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly ISession _session;
        protected readonly IMapper _mapper;

        public GenericRepository(ISession session)
        {
            _session = session;
            _mapper = new Mapper(session);
        }

        public IEnumerable<TEntity> Fetch()
        {
            return _mapper.Fetch<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _mapper.Insert(entity);
        }

        public TEntity FirstOrDefault(Guid id)
        {
            return _mapper.FirstOrDefault<TEntity>("WHERE contact_id = ? ", id);
        }

        public void Delete(Guid id)
        {
            _mapper.Delete<TEntity>("WHERE contact_id = ? ", id);
        }
    }
}
