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
                StaticContentConventionBuilder.AddDirectory("app", @"Content/app")
            );

            conventions.StaticContentsConventions.Add(
              StaticContentConventionBuilder.AddDirectory("bower_components", @"bower_components")
          );

            conventions.StaticContentsConventions.Add(
               StaticContentConventionBuilder.AddDirectory("templates", @"Content/templates")
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