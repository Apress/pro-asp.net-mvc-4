using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers {
    public class ExampleController : Controller {

        public ViewResult Index() {



            return View();
        }


        public RedirectResult Redirect() {
            return RedirectPermanent("/Example/Index");
        }




    public RedirectToRouteResult RedirectToRoute() {
        TempData["Message"] = "Hello";
        TempData["Date"] = DateTime.Now;
        return RedirectToAction("Index", "Example");
    }


    public HttpStatusCodeResult StatusCode() {
        return new HttpUnauthorizedResult();
    }




    }
}
