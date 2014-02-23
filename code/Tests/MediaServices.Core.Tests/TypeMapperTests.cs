using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaServices.Common.Tests;
using MediaServices.Core.Mapping;
using NUnit.Framework;

namespace MediaServices.Core.Tests
{
    [TestFixture]
    public class TypeMapperTests : WithContextFor<TypeMapper>
    {
        public class TestClass1
        {
            public TestClass1()
            {
                Children = new List<TestClass1>();
            }

            public long Id { get; set; }
            public string Description { get; set; }
            public IList<TestClass1> Children { get; set; }
        }

        public class TestClass2
        {
            public long Id { get; set; }
            public string Description { get; set; }
            public IList<TestClass2> Children { get; set; }
        }

        [Test]
        public void CanMapEntitiesRecoursive()
        {
            Subject.CreateMap<TestClass1, TestClass2>();

            TestClass1 top = new TestClass1()
            {
                Id = 1,
                Description = "top"
            };

            TestClass1 topFirst = new TestClass1()
            {
                Id = 2,
                Description = "First"
            };

            TestClass1 topSecond = new TestClass1()
            {
                Id = 3,
                Description = "Second"
            };

            TestClass1 topTopThird = new TestClass1()
            {
                Id = 4,
                Description = "Third"
            };

            topSecond.Children.Add(topTopThird);
            top.Children.Add(topFirst);
            top.Children.Add(topSecond);

            var result = Subject.Map<TestClass1, TestClass2>(top);
            Assert.NotNull(result);
            Assert.IsTrue(result.Children.Count == 2);
            Assert.IsTrue(result.Children.Last().Children.Count == 1);
            Assert.IsTrue(result.Children.Last().Children[0].Id == 4);

        }

        [Test]
        public void ShouldVerifyAllMappingModules()
        {
            //Arrange
            var modules = new IMappingModule[]
                {

                };

            var typeMappingModuleConfiguration = new TypeMappingConfiguration(new TypeMappingModuleProvider(modules), new TypeMapper());

            //Act
            typeMappingModuleConfiguration.Configure();

            //Assert
            Mapper.AssertConfigurationIsValid();
        }
    }
}
