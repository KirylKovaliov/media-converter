using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaService.Access.Tests.ServiceReference1;

namespace MediaService.Access.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ConverterClient client = new ConverterClient();
            client.DoWork();
        }
    }
}
