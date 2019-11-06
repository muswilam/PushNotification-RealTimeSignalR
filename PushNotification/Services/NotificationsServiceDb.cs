using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PushNotification.Models;

namespace PushNotification.Services
{
    public class NotificationsServiceDb
    {
        public Notification GetNotification(int id)
        {
            using (var context = new RealTimeNotiicationCS())
            {
                return context.Notifications.Where(n => n.Id == id).First();
            }
        }

        public bool SaveNotification(Notification notification)
        {
            using (var context = new RealTimeNotiicationCS())
            {
                context.Notifications.Add(notification);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateNotification(Notification notification)
        {
            using (var context = new RealTimeNotiicationCS())
            {
                context.Entry(notification).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteNotification(Notification notification)
        {
            using (var context = new RealTimeNotiicationCS())
            {
                context.Entry(notification).State = System.Data.Entity.EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }

        
    }
}