using Autofac;
using CarPool;
using Carpool.Tests.ServiceStubs;
using Nancy;

namespace Carpool.Tests
{
    public class TestBootstrapper : Bootstrapper
    {
        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            var builder = new ContainerBuilder();
            builder.RegisterType<AuthenticationServiceStub>().As<IAuthenticationService>();

            builder.Update(container.ComponentRegistry);
        }

    }
}