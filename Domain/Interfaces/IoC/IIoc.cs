

using System;

namespace ApacheCassandra.Domain.Interfaces.IoC
{
    public interface IIoc
    {
        void Register<TService, TImplementation>()
           where TService : class
           where TImplementation : class, TService;


        void Register<TService>(Func<TService> instanceCreator) 
            where TService : class;

        TImplementation GetInstance<TImplementation>() where TImplementation : class;

        void Verify();

        void ScopeWrapper(Action executeWithinScope);
    }

    public enum ObjectLifetime
    {
        Transient = 0,
        Singleton = 1,
        Scoped = 2

    }

    public enum ScopedLifetime
    {
        ThreadScoped = 0,
        AsyncScoped = 1,
        WebApiRequest = 2,
        WCFOperation = 3
    }
}
