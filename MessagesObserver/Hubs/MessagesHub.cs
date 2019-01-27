using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;
using MessagesObserver.Interfaces;
using System.Web.Configuration;

namespace MessagesObserver.Hubs
{
    [HubName("messagesHub")]
    public class MessagesHub : Hub
    {
        private readonly int generatingInterval = int.Parse(WebConfigurationManager.AppSettings["generatingInterval"]);
        private readonly IMessagesService _messagesService;

        public MessagesHub(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        public void SendMessages()
        {
            var messages = new List<string>();

            while (true)
            {
                var message = _messagesService.GenerateMessage();

                messages.Add(message);
                Clients.All.addMessages(messages);

                Thread.Sleep(generatingInterval);
            }
        }
    }
}