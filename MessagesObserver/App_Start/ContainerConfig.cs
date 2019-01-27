using MessagesObserver.Interfaces;
using MessagesObserver.Services;
using StructureMap;

namespace MessagesObserver.App_Start
{
    public class ContainerConfig
    {
        public class MessagesRegistry : Registry
        {
            public MessagesRegistry()
            {
                For<IMessagesService>().Use<MessagesService>();
            }
        }
    }
}