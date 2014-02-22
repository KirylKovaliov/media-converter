using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaServices.Converter;
using NUnit.Framework;

namespace MediaService.Converter.Tests
{
    [TestFixture]
    public class ImageExtractorArgumentsBuilderTests
    {
        [Test]
        public void CanBuildValidArgumentsString()
        {
            string result = ImageExtractorArgumentsBuilder.BuildArgumentsString("input.mp4", "output.png");
            const string expectedString = "-i \"input.mp4\" -f image2 -vframes 1 \"output.png\"";

            Assert.IsTrue(result == expectedString);
        }
    }
}
