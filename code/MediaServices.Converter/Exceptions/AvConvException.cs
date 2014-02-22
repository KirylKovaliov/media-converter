using System;

namespace MediaServices.Converter.Exceptions
{
    public class AvConvException : Exception
    {
        public AvConvException(string message, string log)
            : base(message)
        {
            Log = log;
        }

        public string Log { get; private set; }
    }
}
