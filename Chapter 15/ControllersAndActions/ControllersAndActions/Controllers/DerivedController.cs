using ControllersAndActions.Infrastructure;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers {

    public class DerivedController : Controller {

        public ActionResult Index() {
            ViewBag.Message = "Hello from the DerivedController Index method";
            return View("MyView");
        }

public ActionResult ProduceOutput() {
    return Redirect("/Basic/Index");
}
    }
}
