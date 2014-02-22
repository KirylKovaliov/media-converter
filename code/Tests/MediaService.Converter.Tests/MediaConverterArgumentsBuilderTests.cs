using MediaServices.Converter;
using NUnit.Framework;

namespace MediaService.Converter.Tests
{
    [Ignore]
    [TestFixture]
    public class MediaConverterArgumentsBuilderTests
    {
        [Test]
        public void CanBuildArgumentsForOggVideo()
        {
            AvOptions options = new AvOptions
            {
                AudioOptions = new AudioOptions
                {
                    AudioCodec = AudioCodecType.Ogg,
                    Bitrate = "44100",
                },
                VideoOptions = new VideoOptions
                {
                    Bitrate = "1000k",
                    VideoCodec = VideoCodecType.Theora
                },
                InputFile = "movie.avi",
                OutputFile = "movie.mp4"
            };

            string arguments = MediaConverterArgumentsBuilder.BuildArgumentsString(options);

            string expectedResult = string.Format("-i \"{0}\" -ar 44100 -c:v libtheora -vb 1000k -c:a libvorbis -threads 2 -y \"{1}\"", options.InputFile, options.OutputFile);
            Assert.True(arguments == expectedResult);
        }

        [Test]
        public void CanBuildArgumentsForFlashVideo()
        {
            AvOptions options = new AvOptions
            {
                AudioOptions = new AudioOptions
                {
                    Bitrate = "44100",
                },
                VideoOptions = new VideoOptions
                {
                    Bitrate = "1000k",
                    VideoCodec = VideoCodecType.Flash
                },
                Format = "flv",
                InputFile = "movie.avi",
                OutputFile = "movie.flv",
                Overwrite = false,
            };

            string arguments = MediaConverterArgumentsBuilder.BuildArgumentsString(options);
            string expectedResult = string.Format("-i \"{0}\" -ar 44100 -f flv -c:v flv -vb 1000k -threads 2 \"{1}\"", options.InputFile, options.OutputFile);
            Assert.True(arguments == expectedResult);
        }

        [Test]
        public void CanBuildArgumentsForH254Video()
        {
            AvOptions options = new AvOptions
            {
                AudioOptions = new AudioOptions
                {
                    Bitrate = "44100",
                },
                VideoOptions = new VideoOptions
                {
                    Bitrate = "1000k",
                    VideoCodec = VideoCodecType.H254
                },
                InputFile = "movie.avi",
                OutputFile = "movie.mp4",
                Overwrite = false,
            };

            string arguments = MediaConverterArgumentsBuilder.BuildArgumentsString(options);
            string expectedResult = string.Format("-i \"{0}\" -ar 44100 -c:v libx264 -vb 1000k -threads 2 \"{1}\"", options.InputFile, options.OutputFile);
            Assert.True(arguments == expectedResult);
        }

        [Test]
        public void CanBuildArgumentsForMp3Audio()
        {
            AvOptions options = new AvOptions
            {
                VideoOptions = null,
                AudioOptions = new AudioOptions
                {
                    Bitrate = "44100",
                    AudioCodec = AudioCodecType.Mp3
                },
                Format = "mp3",
                InputFile = "test.wav",
                OutputFile = "result.mp3",
                Overwrite = false,
            };

            string arguments = MediaConverterArgumentsBuilder.BuildArgumentsString(options);
            string expectedResult = string.Format("-i \"{0}\" -ar 44100 -f mp3 -c:a libmp3lame -threads 2 \"{1}\"", options.InputFile, options.OutputFile);
            Assert.True(arguments == expectedResult);
        }

        [Test]
        public void CanBuildArgumentsForOggAudio()
        {
            AvOptions options = new AvOptions
            {
                VideoOptions = null,
                AudioOptions = new AudioOptions
                {
                    Bitrate = "44100",
                    AudioCodec = AudioCodecType.Ogg
                },
                InputFile = "test.wav",
                OutputFile = "result.ogg",
                Overwrite = false,
            };

            string arguments = MediaConverterArgumentsBuilder.BuildArgumentsString(options);
            string expectedResult = string.Format("-i \"{0}\" -ar 44100 -c:a libvorbis -threads 2 \"{1}\"", options.InputFile, options.OutputFile);
            Assert.True(arguments == expectedResult);
        }

        [Test]
        public void CanBuildArgumentsForOggFlash()
        {
            AvOptions options = new AvOptions
            {
                VideoOptions = null,
                AudioOptions = new AudioOptions
                {
                    Bitrate = "44100",
                    AudioCodec = AudioCodecType.Copy
                },
                Format = "flv",
                InputFile = "test.wav",
                OutputFile = "result.ogg",
                Overwrite = false,
            };

            string arguments = MediaConverterArgumentsBuilder.BuildArgumentsString(options);
            string expectedResult = string.Format("-i \"{0}\" -ar 44100 -f flv -c:a copy -threads 2 \"{1}\"", options.InputFile, options.OutputFile);
            Assert.True(arguments == expectedResult);
        }
    }
}
