namespace MediaServices.Common.Tests
{
    internal class SpecificationController<T>
    {
        private readonly AutoMockingContainer amc;
        public SpecificationController()
        {
            amc = new AutoMockingContainer();
        }

        public T Subject
        {
            get
            {
                var result = amc.Resolve<T>();
                return result;
            }
            set
            {
                amc.RegisterInstance(value);
            }
        }

        public void With<TDependency>(TDependency dependency)
        {
            amc.RegisterInstance(dependency);
        }        

        public TDependency The<TDependency>() where TDependency: class
        {
            return amc.Resolve<TDependency>();
        }
    }

}
