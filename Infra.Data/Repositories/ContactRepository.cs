using ApacheCassandra.Domain.Entities;
using ApacheCassandra.Domain.Interfaces.Repositories;
using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheCassandra.Infra.Data.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(ISession session) : base(session)
        {
        }
    }
}
