using System;
using System.IO;
using System.Reflection;

namespace MediaServices.Common.Extensions
{
    public static class AssemblyExtensions
    {
        public static string GetAssemblyDirectory(this Assembly assembly)
        {
            Uri uri = new Uri(assembly.CodeBase);
            return new FileInfo(uri.LocalPath).Directory.FullName;
        }
    }
}
