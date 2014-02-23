using System;
using System.Collections.Generic;

namespace MediaServices.Core.Injection
{
    public enum LifeStyle
    {
        Transient,
        Singleton
    }

    public interface IContainer : IServiceProvider
    {
        void Register<TConcrete>(LifeStyle lifeStyle = LifeStyle.Transient) where TConcrete : class;
        void Register<TService, TImplementation>(LifeStyle lifeStyle = LifeStyle.Transient)
            where TService : class
            where TImplementation : class, TService;
        void Register<TService>(Func<TService> instanceCreator) where TService : class;
        void Register<TService>(TService instance) where TService : class;
        void RegisterAll<TService>(params Type[] serviceTypes) where TService : class;
        void Register(Type serviceType, Type implementationType, LifeStyle lifestyle = LifeStyle.Transient);
        void RegisterDecorator<TService, TDecorator>();

        TService Resolve<TService>() where TService : class;
        object Resolve(Type serviceType);
        IEnumerable<TService> ResolveAll<TService>();
        IEnumerable<object> ResolveAll(Type serviceType);
        
        void BuildUp(object instance);
        void RegisterSingle<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        void RegisterPerWebRequest<TConcrete>() where TConcrete : class;
        void RegisterPerWebRequest<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        void RegisterMixedWebRequestAndScopeLifeTime<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        void RegisterPerWebRequest<TService>(Func<TService> instanceCreator) where TService : class;
        IDisposable BeginScope();
    }
}
