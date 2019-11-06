using PushNotification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PushNotification.Services;

namespace PushNotification.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

        public JsonResult GetNotification()
        {
            return Json(NotificationService.GetNotification(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Notification notification)
        {
            NotificationsServiceDb notify = new NotificationsServiceDb();
            var result = notify.SaveNotification(notification);

            if (result)
                return RedirectToAction("Index");

            return View();
        }

        public ActionResult Edit(int id)
        {
            NotificationsServiceDb notify = new NotificationsServiceDb();

            var notification = notify.GetNotification(id);
            return PartialView(notification);
        }

        [HttpPost]
        public ActionResult Edit(Notification notification)
        {
            NotificationsServiceDb notify = new NotificationsServiceDb();

            var result = notify.UpdateNotification(notification);

            if (result)
                return RedirectToAction("Index");

            return View(notification);
        }

        [HttpPost]
        public ActionResult Delete(Notification notification)
        {
            NotificationsServiceDb notify = new NotificationsServiceDb();

            var result = notify.DeleteNotification(notification);

            if (result)
                return RedirectToAction("Index");

            return new HttpStatusCodeResult(500);
        }
    }
}