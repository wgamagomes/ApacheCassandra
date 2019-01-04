using System;

namespace ApacheCassandra.Domain.Entities
{
    public class Contact : Entity
    {      
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
