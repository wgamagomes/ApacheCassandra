using ApacheCassandra.Domain.Entities;
using Cassandra.Mapping;

namespace ApacheCassandra.Infra.Data.Mappers
{
    public class ContactMapper : Mappings
    {
        public ContactMapper()
        {
            For<Contact>()
               .TableName("contacts")
               .PartitionKey(u => u.Id)
               .Column(c => c.Id, s => s.WithName("contact_id"))
               .Column(c => c.Firstname, s => s.WithName("first_name"))
               .Column(c => c.Lastname, s => s.WithName("last_name"))
               .Column(c => c.PhoneNumber, s => s.WithName("phone_number"));
        }
    }
}
