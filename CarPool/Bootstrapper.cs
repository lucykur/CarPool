using System;
using System.Configuration;
using Autofac;
using CarPool.Models;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Conventions;

namespace CarPool
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope container)
        {
            container.Update(builder => builder.RegisterType<HttpClient>()
                .Named<HttpClient>("AuthServiceClient")
                .WithParameter("baseAddress", ConfigurationManager.AppSettings["AuthService"])
                .AsSelf());

            base.ConfigureApplicationContainer(container);
        }

        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            container.Update(builder =>
            {
                builder.RegisterType<UserMapper>().As<IUserMapper>();
                builder.RegisterType<AuthenticationService>()
                   .WithParameter("httpClient", container.ResolveNamed<HttpClient>("AuthServiceClient"))
                   .AsSelf();
            });

            base.ConfigureRequestContainer(container, context);
        }

        protected override void RequestStartup(ILifetimeScope container,IPipelines pipelines,NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            var formsAuthenticationConfiguration = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/login",
                UserMapper = container.Resolve<IUserMapper>()
            };
            
            FormsAuthentication.Enable(pipelines, formsAuthenticationConfiguration);
        }

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
               StaticContentConventionBuilder.AddDirectory("templates", @"app/templates")
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