using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaServices.Converter;
using MediaServices.Converter.Exceptions;
using NUnit.Framework;

namespace MediaService.Converter.Tests
{
    [TestFixture]
    public class MediaConvertorTests
    {
        private const string OutputDir = "AvTestResults";

        [SetUp]
        public void Setup()
        {
            if (Directory.Exists(OutputDir))
                Directory.Delete(OutputDir, true);

            Directory.CreateDirectory(OutputDir);
        }

        [Test]
        [ExpectedException(typeof(AvConvException))]
        [Ignore]
        public void CannotConvertWithInvalidArguments()
        {
            try
            {
                var options = AvOptions.FlashVideo(@"Data\movie.mp5", string.Format(@"{0}\result.flv", OutputDir));
                MediaConvertor converter = new MediaConvertor();
                Task task = converter.Convert(options);

                Task.WaitAll(task);
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }
        }

        [Test]
        public void CanConvertVideoToFlash()
        {
            var options = AvOptions.FlashVideo(@"Data\movie.mp4", string.Format(@"{0}\result.flv", OutputDir));
            MediaConvertor converter = new MediaConvertor();
            Task task = converter.Convert(options);

            Task.WaitAll(task);
            Assert.IsTrue(File.Exists(string.Format(@"{0}\result.flv", OutputDir)));
        }

        [Test]
        public void CanConvertVideoToH254()
        {
            var options = AvOptions.H254Video(@"Data\movie.mp4", string.Format(@"{0}\result.mp4", OutputDir));
            MediaConvertor converter = new MediaConvertor();
            Task task = converter.Convert(options);

            Task.WaitAll(task);
            Assert.IsTrue(File.Exists(string.Format(@"{0}\result.mp4", OutputDir)));
        }

        [Test]
        public void CanConvertVideoToOgv()
        {
            var options = AvOptions.OggVideo(@"Data\movie.mp4", string.Format(@"{0}\result.ogv", OutputDir));
            MediaConvertor converter = new MediaConvertor();
            Task task = converter.Convert(options);

            Task.WaitAll(task);
            Assert.IsTrue(File.Exists(string.Format(@"{0}\result.ogv", OutputDir)));
        }

        [Test]
        public void CanConvertAudioToOgg()
        {
            var options = AvOptions.OggAudio(@"Data\jazz.mp3", string.Format(@"{0}\result.ogg", OutputDir));
            MediaConvertor converter = new MediaConvertor();
            Task task = converter.Convert(options);

            Task.WaitAll(task);
            Assert.IsTrue(File.Exists(string.Format(@"{0}\result.ogg", OutputDir)));
        }

        [Test]
        public void CanConvertAudioToOgg2()
        {
            var options = AvOptions.OggAudio(@"Data\08 бэйба-лэйба.mp3", string.Format(@"{0}\result.ogg", OutputDir));
            MediaConvertor converter = new MediaConvertor();
            Task task = converter.Convert(options);

            Task.WaitAll(task);
            Assert.IsTrue(File.Exists(string.Format(@"{0}\result.ogg", OutputDir)));
        }

        [Test]
        public void CanConvertAudioToFlash()
        {
            var options = AvOptions.FlashAudio(@"Data\jazz.mp3", string.Format(@"{0}\result.flv", OutputDir));
            MediaConvertor converter = new MediaConvertor();
            Task task = converter.Convert(options);

            Task.WaitAll(task);
            Assert.IsTrue(File.Exists(string.Format(@"{0}\result.flv", OutputDir)));
        }

        [Test]
        public void CanConvertAudioToMp3()
        {
            var options = AvOptions.Mp3Audio(@"Data\jazz.mp3", string.Format(@"{0}\result.mp3", OutputDir));
            MediaConvertor converter = new MediaConvertor();
            Task task = converter.Convert(options);

            Task.WaitAll(task);
            Assert.IsTrue(File.Exists(string.Format(@"{0}\result.mp3", OutputDir)));
        }

        [Test]
        public void CanExtractPreview()
        {
            string output = string.Format(@"{0}\preview.png", OutputDir);

            MediaConvertor converter = new MediaConvertor();
            Task task = converter.ExtractPreview(@"Data\movie.mp4", output);

            Task.WaitAll(task);

            Assert.IsTrue(File.Exists(output));
        }

        [Test]
        public void CanConvertToWebmAudio()
        {
            var options = AvOptions.WebmAudio(@"Data\jazz.mp3", string.Format(@"{0}\result.webm", OutputDir));
            MediaConvertor converter = new MediaConvertor();
            Task task = converter.Convert(options);

            Task.WaitAll(task);
            Assert.IsTrue(File.Exists(string.Format(@"{0}\result.webm", OutputDir)));
        }

        [Test]
        public void CanConvertToWebmVideo()
        {
            var options = AvOptions.WebmVideo(@"Data\movie.mp4", string.Format(@"{0}\result.webm", OutputDir));
            MediaConvertor converter = new MediaConvertor();
            Task task = converter.Convert(options);

            Task.WaitAll(task);
            Assert.IsTrue(File.Exists(string.Format(@"{0}\result.webm", OutputDir)));
        }
    }
}
