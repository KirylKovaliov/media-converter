using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;

namespace MediaServices.Common.Tests
{
    class AutoMockingContainer
    {
        readonly IDictionary<Type, object> instances = new Dictionary<Type, object>();
        
        public void RegisterInstance<T>(T instance)
        {
            RegisterInstance(typeof(T), instance);
        }

        private void RegisterInstance(Type type, object instance)
        {
            instances[type] = instance;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            if (instances.ContainsKey(type))
                return instances[type];

            object o = Instantiate(type);
            RegisterInstance(type, o);
            return o;
        }

        public object Instantiate(Type type)
        {
            if (type.IsInterface)
                return Substitute.For(new[] { type }, new object[0]);
            var constructorInfo = type.GetConstructors().OrderByDescending(x => x.GetParameters().Length).First();

            var constructorParameters = constructorInfo.GetParameters();
            var args = new List<object>();
            foreach (var parameterInfo in constructorParameters)
            {
                args.Add(Resolve(parameterInfo.ParameterType));
            }

            return constructorInfo.Invoke(args.ToArray());
        }
    }
}

