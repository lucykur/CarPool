using System;
using Nancy;
using Nancy.Conventions;

namespace CarPool
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new CustomRootPathProvider(); }
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("dist", @"app/dist")
            );

            conventions.StaticContentsConventions.Add(
              StaticContentConventionBuilder.AddDirectory("node_modules", @"node_modules")
          );

            conventions.StaticContentsConventions.Add(
               StaticContentConventionBuilder.AddDirectory("templates", @"templates")
           );
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