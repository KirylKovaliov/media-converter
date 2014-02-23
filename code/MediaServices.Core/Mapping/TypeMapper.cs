using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace MediaServices.Core.Mapping
{
    public interface IMapper
    {
        IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>();
        TDestination Map<TSource, TDestination>(TSource source);
        object Map(object source, Type sourceType, Type destinationType);
        Type GetDestinationType<TSource>(TSource source);
        void InitializeServiceLocator(Func<Type, object> constructor);
        IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> source);
    }

    public class TypeMapper : IMapper
    {
        public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
        {            
            return Mapper.CreateMap<TSource, TDestination>();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);            
        }

        public Type GetDestinationType<TSource>(TSource source)
        {            
            return Mapper.GetAllTypeMaps().FirstOrDefault(t => t.SourceType == source.GetType()).DestinationType;
        }

        public void InitializeServiceLocator(Func<Type, object> constructor)
        {
            Mapper.Initialize(configuration => configuration.ConstructServicesUsing(constructor));
        }

        public IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return source.Select(x => Map<TSource, TDestination>(x));
        }
    }
}