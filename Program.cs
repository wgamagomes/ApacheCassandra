using ApacheCassandra.Domain.Entities;
using ApacheCassandra.Domain.Interfaces.IoC;
using ApacheCassandra.Domain.Interfaces.Repositories;
using ApacheCassandra.Infra.CrossCutting.IoC;
using ApacheCassandra.Infra.Data.Repositories;
using ApacheCassandra.Infra.Data.Utils;
using System;
using Session = ApacheCassandra.Infra.Data.Builders.Session;

namespace ApacheCassandra
{
    class Program
    {
        static void Main(string[] args)
        {

            IIoc ioc = new DependencyInjector(ScopedLifetime.AsyncScoped);

            ioc.Register(() =>
            {
                return Session.Builder()
                                 .AddContactPoints(AppSettingsKeys.CassandraAddress)
                                 .WithPort(AppSettingsKeys.CassandraPort)
                                 .Connect(AppSettingsKeys.Cassandrakeyspace)
                                 .Build();
            });

            ioc.Register<IContactRepository, ContactRepository>();

            ioc.ScopeWrapper(() =>
            {
                var repository = ioc.GetInstance<IContactRepository>();

                //Search
                foreach (var row in repository.Fetch())
                {
                    Console.WriteLine($"{row.Id} {row.Firstname} {row.Lastname} {row.PhoneNumber}");
                }

                //Insert
                var id = Guid.NewGuid();
                repository.Insert(new Contact { Id = id, Firstname = "John", Lastname = " Doe", PhoneNumber = "559912341234" });

                //FirstOrDefault
                var firstOrDefault = repository.FirstOrDefault(id);

                //Delete
                repository.Delete(firstOrDefault.Id);

            });
        }
    }
}
