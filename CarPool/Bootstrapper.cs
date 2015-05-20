using System;
using Nancy;

namespace CarPool
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new CustomRootPathProvider(); }
        }

    }

    public class CustomRootPathProvider : IRootPathProvider
    {
        private readonly string _rootPath = Environment.CurrentDirectory;

        public string GetRootPath()
        {
            return _rootPath;
        }
    }
}