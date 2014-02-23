using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace MediaServices.Common.Tests
{
    public class WithContextFor<TSubject> where TSubject : class
    {
        private static SpecificationController<TSubject> SpecificationController;

        protected WithContextFor()
        {
            
        }

        protected static TSubject Subject
        {
            get { return SpecificationController.Subject; }
            set { SpecificationController.Subject = value; }
        }

        protected static void With<TDependency>(TDependency implementation)
        {
            SpecificationController.With(implementation);
        }

        protected static void WithMultiple<TDependency>(params TDependency[] implementations)
        {
            SpecificationController.With((IEnumerable<TDependency>)implementations);
        }

        protected static TDependency The<TDependency>() where TDependency : class
        {
            return SpecificationController.The<TDependency>();
        }

        protected static TService An<TService>() where TService : class
        {
            return Substitute.For<TService>();
        }

        protected static TService A<TService>() where TService : class
        {
            return Substitute.For<TService>();
        }

        [SetUp]
        public virtual void Setup()
        {
            SpecificationController = new SpecificationController<TSubject>();
        }
    }

    public class WithContextFor<TSubject, TResult> : WithContextFor<TSubject>
        where TSubject : class
    {
        protected static TResult Result;

        public WithContextFor()
        {
            Result = default(TResult);
        }
    }}
