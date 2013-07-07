using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Before.Controllers
{
    public class HomeController : AsyncController
    {
        private readonly object _lock = new object();
        public void IndexAsync()
        {
            AsyncManager.OutstandingOperations.Increment(2);
            GetFacebookLikes();
            GetFaceBookCommentsCount();

        }
        public ActionResult IndexCompleted(string facebookLikes, string commentsCount)
        {
            ViewData["FacebookLikes"] = facebookLikes;
            ViewData["CommentsCount"] = commentsCount;
            return View("Index");
        }
        void GetFacebookLikes()
        {
            lock (_lock)
            {
                Thread.Sleep(2000);
                AsyncManager.Parameters["FacebookLikes"] = "15";
            }
            //last line of this method

            AsyncManager.OutstandingOperations.Decrement();
        }
        void GetFaceBookCommentsCount()
        {
            lock (_lock)
            {
                Thread.Sleep(2000);
                AsyncManager.Parameters["CommentsCount"] = "20";
            }
            //last line of this method

            AsyncManager.OutstandingOperations.Decrement();
        }
    }
}
