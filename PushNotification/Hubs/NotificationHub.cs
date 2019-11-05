using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushNotification.Hubs
{
    public class NotificationHub : Hub
    {
        public static void Send()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.displayStatus();
        }
    }
}