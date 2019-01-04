using ApacheCassandra.Infra.Data.Mappers;
using ApacheCassandra.Infra.Data.Utils;
using Cassandra;
using Cassandra.Mapping;
using System;


namespace ApacheCassandra.Infra.Data.Builders
{
    public class SessionBuilder
    {
        private Builder _builder;
        private ISession _session;

        public SessionBuilder()
        {
            _builder = Cluster.Builder();
        }

        private static bool _mapped;
        public ISession Build()
        {
            if (!_mapped)
            {
                MappingConfiguration.Global.Define(new ContactMapper());
                _mapped = !_mapped;
            }
            return _session;
        }

        public SessionBuilder Connect(string keyspace)
        {
            _session = _builder.Build()
                               .Connect(keyspace.GetAppSettings());
            return this;
        }

        public SessionBuilder AddContactPoints(string AdressesKey)
        {
            _builder.AddContactPoints(AdressesKey.GetAppSettings().Split(','));
            return this;
        }

        public SessionBuilder WithPort(string portKey)
        {
            _builder.WithPort(int.Parse((portKey.GetAppSettings())));
            return this;
        }

        public SessionBuilder WithCredentials(string userKey, string passwordKey)
        {
            _builder.WithCredentials(userKey.GetAppSettings(), passwordKey.GetAppSettings());
            return this;
        }

        public SessionBuilder WithQueryOptions()
        {
            throw new NotImplementedException();
        }
    }
}
