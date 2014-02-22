using System;
using System.Text;

namespace MediaServices.Converter
{
    public static class ImageExtractorArgumentsBuilder
    {
        public static string BuildArgumentsString(string input, string output)
        {
            StringBuilder result = new StringBuilder();
            AppendInputFile(result, input);
            AppendSpace(result);
            AppendFormat(result);
            AppendSpace(result);
            AppendFramesCount(result, 1);
            AppendSpace(result);
            AppendOutputFile(result, output);

            return result.ToString();
        }

        private static void AppendOutputFile(StringBuilder argumentString, string output)
        {
            if (string.IsNullOrEmpty(output))
                throw new ArgumentException("Output file is not defined");

            argumentString.AppendFormat("\"{0}\"", output);
        }

        private static void AppendFramesCount(StringBuilder argumentString, int count)
        {
            argumentString.AppendFormat("-vframes {0}", count);
        }

        private static void AppendFormat(StringBuilder argumentString)
        {
            argumentString.Append("-f image2");
        }

        private static void AppendInputFile(StringBuilder argumentString, string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input file is not defined");

            argumentString.AppendFormat("-i \"{0}\"", input);
        }

        private static void AppendSpace(StringBuilder argumentString)
        {
            if (argumentString[argumentString.Length - 1] != ' ')
                argumentString.Append(" ");
        }
    }
}
