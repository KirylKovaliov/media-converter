namespace MediaServices.Core.Mapping
{
    public interface ITypeMappingConfiguration
    {
        void Configure();
    }

    public class TypeMappingConfiguration : ITypeMappingConfiguration
    {
        private readonly ITypeMappingModuleProvider moduleProvider;
        private readonly IMapper mapper;        
        
        public TypeMappingConfiguration(ITypeMappingModuleProvider moduleProvider, IMapper mapper)
        {
            this.moduleProvider = moduleProvider;
            this.mapper = mapper;            
        }

        public void Configure()
        {
            var mappingModules = moduleProvider.GetModules();
            foreach (var typeMappingModule in mappingModules)
            {
                typeMappingModule.Register(mapper);
            }
        }
    }
}