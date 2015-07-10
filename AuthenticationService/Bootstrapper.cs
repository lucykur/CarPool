using System;
using Autofac;
using Nancy;
using Nancy.Bootstrappers.Autofac;

namespace AuthenticationService
{
    public class Bootstrapper :AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope container)
        {
            base.ConfigureApplicationContainer(container);

            var builder = new ContainerBuilder();
            builder.RegisterType<UserRepository>().AsSelf();
            builder.Update(container.ComponentRegistry);

        }

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