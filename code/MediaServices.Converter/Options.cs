namespace MediaServices.Converter
{
    public class AvOptions
    {
        public static AvOptions WebmAudio(string inputFile, string outputFile)
        {
            AvOptions options = new AvOptions
            {
                AudioOptions = new AudioOptions
                {
                    Bitrate = string.Empty,
                    AudioCodec = AudioCodecType.Ogg
                },
                VideoOptions = null,
                Overwrite = true,
                InputFile = inputFile,
                OutputFile = outputFile,
            };

            return options;
        }

        public static AvOptions WebmVideo(string inputFile, string outputFile)
        {
            AvOptions options = new AvOptions
            {
                AudioOptions = new AudioOptions
                {
                    Bitrate = string.Empty,
                    AudioCodec = AudioCodecType.Ogg
                },
                VideoOptions = new VideoOptions
                {
                    Bitrate = "1000k",
                    VideoCodec = VideoCodecType.VP8,
                    //VideoCompression = null,
                },
                Overwrite = true,
                InputFile = inputFile,
                OutputFile = outputFile,
            };

            return options;
        }

        public static AvOptions FlashVideo(string inputFile, string outputFile)
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
                Overwrite = true,
                Format = "flv",
                InputFile = inputFile,
                OutputFile = outputFile,
            };

            return options;
        }

        public static AvOptions OggVideo(string inputFile, string outputFile)
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
                    VideoCodec = VideoCodecType.Theora,
                    //VideoCompression = null,
                },
                Overwrite = true,
                InputFile = inputFile,
                OutputFile = outputFile,
            };

            return options;
        }

        public static AvOptions H254Video(string inputFile, string outputFile)
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
                Overwrite = true,
                InputFile = inputFile,
                OutputFile = outputFile,
            };

            return options;
        }

        public static AvOptions FlashAudio(string inputFile, string outputFile)
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
                InputFile = inputFile,
                OutputFile = outputFile,
                Overwrite = true,
            };

            return options;
        }

        public static AvOptions Mp3Audio(string inputFile, string outputFile)
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
                InputFile = inputFile,
                OutputFile = outputFile,
                Overwrite = true,
            };

            return options;
        }

        public static AvOptions OggAudio(string inputFile, string outputFile)
        {
            AvOptions options = new AvOptions
            {
                VideoOptions = null,
                AudioOptions = new AudioOptions
                {
                    Bitrate = "44100",
                    AudioCodec = AudioCodecType.Ogg,
                },

                InputFile = inputFile,
                OutputFile = outputFile,
                Overwrite = true,
            };

            return options;
        }

        public AvOptions()
        {
            Overwrite = true;
            Threads = 8;
        }

        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public VideoOptions VideoOptions { get; set; }
        public AudioOptions AudioOptions { get; set; }
        public string Format { get; set; }
        public bool Overwrite { get; set; }
        public int Threads { get; set; }
    }

    public enum AudioType
    {
        Mono = 1,
        Stereo = 2,
    }

    public class VideoOptions
    {
        public VideoOptions()
        {
            VideoCodec = VideoCodecType.H254;
            Bitrate = "1000k";
            VideoCompression = 25;
        }

        public int? VideoCompression { get; set; }
        public VideoCodecType? VideoCodec { get; set; }
        public string Bitrate { get; set; }
    }

    public class AudioOptions
    {
        public AudioOptions()
        {
            Bitrate = "44100";
            Audio = AudioType.Stereo;
            AudioQuality = 5;
        }

        public int? AudioQuality { get; set; }
        public AudioType? Audio { get; set; }
        public AudioCodecType? AudioCodec { get; set; }
        public string Bitrate { get; set; }
    }
}
