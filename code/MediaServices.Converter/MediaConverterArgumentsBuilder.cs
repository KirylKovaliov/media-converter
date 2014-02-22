using System;
using System.Text;
using MediaServices.Common;

namespace MediaServices.Converter
{
    public class MediaConverterArgumentsBuilder
    {
        public static string BuildArgumentsString(AvOptions options)
        {
            StringBuilder result = new StringBuilder();
            AppendInputFile(result, options);
            AppendSpace(result);
            AppendAudioBitrate(result, options);
            AppendSpace(result);
            AppendFormat(result, options);
            AppendSpace(result);
            AppendVideoCodec(result, options);
            AppendSpace(result);
            AppendVideoBitrate(result, options);
            AppendSpace(result);
            AppendVideoCompression(result, options);
            AppendSpace(result);
            AppendAudioCodec(result, options);
            AppendSpace(result);
            AppendAudioType(result, options);
            AppendSpace(result);
            AppendAudioQuality(result, options);
            AppendSpace(result);
            AppendThreads(result, options);
            AppendSpace(result);
            AppendOverwriteOption(result, options);
            AppendSpace(result);
            AppendOutputFile(result, options);

            return result.ToString();
        }

        private static void AppendInputFile(StringBuilder argumentString, AvOptions options)
        {
            if (string.IsNullOrEmpty(options.InputFile))
                throw new ArgumentException("Input file is not defined");

            argumentString.AppendFormat("-i \"{0}\"", options.InputFile);
        }

        private static void AppendFormat(StringBuilder argumentString, AvOptions options)
        {
            if (!string.IsNullOrEmpty(options.Format))
                argumentString.AppendFormat("-f {0}", options.Format);
        }

        private static void AppendAudioCodec(StringBuilder argumentString, AvOptions options)
        {
            if (options.AudioOptions.AudioCodec.HasValue)
                argumentString.AppendFormat("-c:a {0}", EnumUtils.GetDescription(options.AudioOptions.AudioCodec.Value));
        }

        private static void AppendVideoBitrate(StringBuilder argumentString, AvOptions options)
        {
            if (options.VideoOptions != null && !string.IsNullOrEmpty(options.VideoOptions.Bitrate))
                argumentString.AppendFormat("-vb {0}", options.VideoOptions.Bitrate);
        }

        private static void AppendVideoCodec(StringBuilder argumentString, AvOptions options)
        {
            if (options.VideoOptions != null && options.VideoOptions.VideoCodec.HasValue)
                argumentString.AppendFormat("-c:v {0}", EnumUtils.GetDescription(options.VideoOptions.VideoCodec.Value));
        }

        private static void AppendAudioBitrate(StringBuilder argumentString, AvOptions options)
        {
            if (!string.IsNullOrEmpty(options.AudioOptions.Bitrate))
                argumentString.AppendFormat("-ar {0}", options.AudioOptions.Bitrate);
        }

        private static void AppendOverwriteOption(StringBuilder argumentString, AvOptions options)
        {
            if (options.Overwrite)
                argumentString.Append("-y");
        }

        private static void AppendOutputFile(StringBuilder argumentString, AvOptions options)
        {
            if (string.IsNullOrEmpty(options.OutputFile))
                throw new ArgumentException("Output file is not defined");

            argumentString.AppendFormat("\"{0}\"", options.OutputFile);
        }

        private static void AppendSpace(StringBuilder argumentString)
        {
            if (argumentString[argumentString.Length - 1] != ' ')
                argumentString.Append(" ");
        }

        private static void AppendThreads(StringBuilder argumentString, AvOptions options)
        {
            argumentString.AppendFormat("-threads {0}", options.Threads);
        }

        private static void AppendAudioType(StringBuilder argumentString, AvOptions options)
        {
            if (options.AudioOptions != null && options.AudioOptions.Audio.HasValue)
                argumentString.AppendFormat("-ac {0}", (int)options.AudioOptions.Audio);
        }

        private static void AppendAudioQuality(StringBuilder argumentString, AvOptions options)
        {
            if (options.AudioOptions != null && options.AudioOptions.AudioQuality.HasValue)
                argumentString.AppendFormat("-aq {0}", (int)options.AudioOptions.AudioQuality.Value);
        }

        private static void AppendVideoCompression(StringBuilder argumentString, AvOptions options)
        {
            if (options.VideoOptions != null && options.VideoOptions.VideoCompression.HasValue)
                argumentString.AppendFormat("-qmax {0}", (int)options.VideoOptions.VideoCompression.Value);
        }
    }
}
