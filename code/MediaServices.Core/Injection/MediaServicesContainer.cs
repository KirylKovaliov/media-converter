using System;
using System.Collections.Generic;
using System.Web;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Extensions.LifetimeScoping;
using SimpleInjector.Integration.Web;

namespace MediaServices.Core.Injection
{
    public class PostAgainContainer : IContainer
    {
        private readonly Container container;

        public PostAgainContainer()
            : this(new Container())
        {
        }

        public PostAgainContainer(Container container)
        {
            this.container = container;
            this.container.EnableLifetimeScoping();
        }

        public void Register<TConcrete>(LifeStyle lifeStyle = LifeStyle.Transient) where TConcrete : class
        {
            if (lifeStyle == LifeStyle.Transient)
            {
                container.Register<TConcrete>();
            }
            else
            {
                container.RegisterSingle<TConcrete>();
            }
        }

        public void Register<TService, TImplementation>(LifeStyle lifeStyle = LifeStyle.Transient)
            where TService : class
            where TImplementation : class, TService
        {
            container.Register<TService, TImplementation>(ToSimpleInjectorLifestyle(lifeStyle));
        }

        public void RegisterSingle<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            Register<TService, TImplementation>(LifeStyle.Singleton);
        }

        public void RegisterPerWebRequest<TConcrete>() where TConcrete : class
        {
            container.RegisterPerWebRequest<TConcrete>();
        }

        public void RegisterPerWebRequest<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            container.RegisterPerWebRequest<TService, TImplementation>();
        }

        public void RegisterMixedWebRequestAndScopeLifeTime<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            var hybridLifestyle = Lifestyle.CreateHybrid(() => HttpContext.Current != null,
                                            new WebRequestLifestyle(),
                                            new LifetimeScopeLifestyle());

            container.Register<TService, TImplementation>(hybridLifestyle);
        }

        public void RegisterPerWebRequest<TService>(Func<TService> instanceCreator) where TService : class
        {
            container.RegisterPerWebRequest<TService>(instanceCreator);
        }

        public IDisposable BeginScope()
        {
            return container.BeginLifetimeScope();
        }

        public void Register<TService>(Func<TService> instanceCreator) where TService : class
        {
            container.Register(instanceCreator);
        }

        public void Register<TService>(TService instance) where TService : class
        {
            container.RegisterSingle(instance);
        }

        public void RegisterAll<TService>(params Type[] serviceTypes) where TService : class
        {
            container.RegisterAll<TService>(serviceTypes);
        }

        public void Register(Type serviceType, Type implementationType, LifeStyle lifestyle = LifeStyle.Transient)
        {
            container.Register(serviceType, implementationType, ToSimpleInjectorLifestyle(lifestyle));
        }

        public void RegisterDecorator<TService, TDecorator>()
        {
            container.RegisterDecorator(typeof(TService), typeof(TDecorator));
        }

        public TService Resolve<TService>() where TService : class
        {
            return container.GetInstance<TService>();
        }

        public object Resolve(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public IEnumerable<TService> ResolveAll<TService>()
        {
            return container.GetAllInstances<TService>();
        }

        public IEnumerable<object> ResolveAll(Type serviceType)
        {
            return container.GetAllInstances(serviceType);
        }

        public void BuildUp(object instance)
        {
            container.InjectProperties(instance);
        }

        private Lifestyle ToSimpleInjectorLifestyle(LifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case LifeStyle.Singleton:
                    return Lifestyle.Singleton;
                default:
                    return Lifestyle.Transient;
            }
        }

        public object GetService(Type serviceType)
        {
            return ((IServiceProvider)container).GetService(serviceType);
        }
    }
}
