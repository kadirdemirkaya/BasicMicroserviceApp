using System.Reflection;

namespace BasicMicroserviceApp.Article.Service
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
