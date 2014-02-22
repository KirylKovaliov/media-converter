using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MediaServices.Common.Extensions;
using MediaServices.Converter.Exceptions;

namespace MediaServices.Converter
{
    public class MediaConvertor
    {
        private const string FFMpeg = "ffmpeg.exe";
        private const string AVConv = "avconv.exe";


        public Task<string> Convert(AvOptions options)
        {
            string fileName = GetExeFileName(options);

            return Run(MediaConverterArgumentsBuilder.BuildArgumentsString(options), fileName);
        }

        public Task<string> ExtractPreview(string inputFile, string outputFile)
        {
            return Run(ImageExtractorArgumentsBuilder.BuildArgumentsString(inputFile, outputFile), FFMpeg);
        }

        private Task<string> Run(string arguments, string fileName)
        {
            Task<string> task = new Task<string>(() => RunInternal(arguments, fileName));
            task.Start();
            return task;
        }

        private string RunInternal(string arguments, string fileName)
        {
            StringBuilder result = new StringBuilder();

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Path.Combine(typeof(MediaConvertor).Assembly.GetAssemblyDirectory(), string.Format(@"AVConv\{0}", fileName));
            startInfo.Arguments = arguments;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            process.StartInfo = startInfo;
            process.ErrorDataReceived += (sender, args) => Common.Log.Error("Error during video converion: '{0}'", args.Data);
            process.OutputDataReceived += (sender, args) => Common.Log.Debug("Video converting: {0}", args.Data);
            process.Start();
            while (!process.StandardError.EndOfStream)
            {
                string line = process.StandardError.ReadLine();
                result.AppendLine(line);
                Common.Log.Debug("Video converting: {0}", line);
            }

            process.WaitForExit();

            if (process.ExitCode != 0)
                throw new AvConvException("File converion failed", result.ToString());

            return result.ToString();
        }

        private string GetExeFileName(AvOptions options)
        {
            return options.VideoOptions != null && options.VideoOptions.VideoCodec.HasValue &&
                   options.VideoOptions.VideoCodec.Value == VideoCodecType.VP8
                       ? AVConv
                       : FFMpeg;
        }
    }
}
