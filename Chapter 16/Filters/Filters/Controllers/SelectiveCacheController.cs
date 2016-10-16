using System;
using System.Web.Mvc;

namespace Filters.Controllers {
    public class SelectiveCacheController : Controller {

        public ActionResult Index() {
            Response.Write("Action method is running: " + DateTime.Now);
            return View();
        }

        [OutputCache(Duration = 30)]
        public ActionResult ChildAction() {
            Response.Write("Child action method is running: " + DateTime.Now);
            return View();
        }
    }
}
