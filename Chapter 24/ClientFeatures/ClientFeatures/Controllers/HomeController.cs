using System;
using System.Web.Mvc;
using ClientFeatures.Models;

namespace ClientFeatures.Controllers {
    public class HomeController : Controller {

        public ViewResult MakeBooking() {
            return View(new Appointment {
                ClientName = "Adam",
                Date = DateTime.Now.AddDays(2),
                TermsAccepted = true
            });
        }

        [HttpPost]
        public JsonResult MakeBooking(Appointment appt) {
            // statements to store new Appointment in a
            // repository would go here in a real project
            return Json(appt, JsonRequestBehavior.AllowGet);
        }
    }
}
