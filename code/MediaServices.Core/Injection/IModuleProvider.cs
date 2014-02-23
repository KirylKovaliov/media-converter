using System.Collections.Generic;

namespace MediaServices.Core.Injection
{
    public interface IModuleProvider
    {
        IEnumerable<IModule> GetModules();
    }
}
