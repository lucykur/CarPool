using System.Collections.Generic;
using Autofac;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;

namespace AuthenticationService
{
    public class Bootstrapper :AutofacNancyBootstrapper
    {
        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            container.Update(builder => builder.RegisterType<UserRepository>().AsSelf());
           
            base.ApplicationStartup(container, pipelines);

        }

    }
}