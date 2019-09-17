using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SignalIRChatAppTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChatRoom(string roomName = "")
        {
            ViewBag.RoomName = roomName;
            return View();
        }
    }
}
