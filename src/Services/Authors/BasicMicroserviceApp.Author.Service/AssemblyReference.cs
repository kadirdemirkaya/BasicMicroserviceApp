using System.Reflection;

namespace BasicMicroserviceApp.Author.Service
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
