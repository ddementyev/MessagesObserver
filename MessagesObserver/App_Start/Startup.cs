using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Owin;
using StructureMap;
using static MessagesObserver.App_Start.ContainerConfig;

[assembly: OwinStartup(typeof(MessagesObserver.App_Start.Startup))]
namespace MessagesObserver.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.AddRegistry(new MessagesRegistry());
            });

            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => new HubActivator(container));

            app.MapSignalR();
        }

        public class HubActivator : IHubActivator
        {
            private readonly IContainer container;

            public HubActivator(IContainer container)
            {
                this.container = container;
            }

            public IHub Create(HubDescriptor descriptor)
            {
                return (IHub)container.GetInstance(descriptor.HubType);
            }
        }
    }
}