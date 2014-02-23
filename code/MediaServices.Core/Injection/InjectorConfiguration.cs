using System;

namespace MediaServices.Core.Injection
{
    public static class InjectorConfiguration
    {
        private static bool IsInitialized;

        private static Lazy<IModuleProvider> InnerModuleProvider;
        private static Lazy<IContainer> InnerContainer;

        static InjectorConfiguration()
        {
            InnerContainer = new Lazy<IContainer>(() => new PostAgainContainer());
        }

        public static IContainer Container
        {
            get
            {
                CheckIfInitialized();
                return InnerContainer.Value;
            }

            set
            {
                CheckIfNotInitialized();
                InnerContainer = new Lazy<IContainer>(() => value);
            }
        }

        public static IModuleProvider ModuleProvider
        {
            get
            {
                CheckIfInitialized();
                return InnerModuleProvider.Value;
            }

            set
            {
                CheckIfNotInitialized();
                InnerModuleProvider = new Lazy<IModuleProvider>(() => value);
            }
        }

        public static void Initialize()
        {
            IsInitialized = true;

            var modules = ModuleProvider.GetModules();
            foreach (var module in modules)
            {
                module.Register(Container);
            }
        }

        private static void CheckIfInitialized()
        {
            if (!IsInitialized) throw new InvalidOperationException("The injector needs to be initialized.");
        }

        private static void CheckIfNotInitialized()
        {
            if (IsInitialized) throw new InvalidOperationException("The injector has been already initialized.");
        }
    }
}
