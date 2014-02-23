using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaServices.Core.Injection
{
    public static class IoC
    {
        public static Func<IDisposable> StartUnitOfWork = () =>
        {
            throw new InvalidOperationException("IoC is not initialized.");
        };
        
        public static Func<Type, string, object> GetInstance = (service, key) =>
        {
            throw new InvalidOperationException("IoC is not initialized.");
        };

        public static Func<Type, IEnumerable<object>> GetAllInstances = service =>
        {
            throw new InvalidOperationException("IoC is not initialized.");
        };

        public static Action<object> BuildUp = instance =>
        {
            throw new InvalidOperationException("IoC is not initialized.");
        };

        public static T Get<T>(string key = null)
        {
            return (T)GetInstance(typeof(T), key);
        }

        public static IEnumerable<T> GetAll<T>()
        {
            return Enumerable.Cast<T>(GetAllInstances(typeof(T)));
        }
    }
}
