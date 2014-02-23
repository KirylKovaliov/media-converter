using System.Collections.Generic;

namespace MediaServices.Core.Mapping
{
    public interface ITypeMappingModuleProvider
    {
        IEnumerable<IMappingModule> GetModules();
    }

    public class TypeMappingModuleProvider : ITypeMappingModuleProvider
    {
        private readonly IEnumerable<IMappingModule> modules;
        
        public TypeMappingModuleProvider(IEnumerable<IMappingModule> modules)
        {
            this.modules = modules;
        }

        public IEnumerable<IMappingModule> GetModules()
        {
            return modules;
        }
    }
}