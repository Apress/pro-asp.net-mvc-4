using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControllersAndActions.Controllers;
using System.Web.Mvc;

namespace ControllersAndActions.Tests {
    [TestClass]
    public class ActionTests {

        [TestMethod]
        public void ViewSelectionTest() {

            // Arrange - create the controller
            ExampleController target = new ExampleController();

            // Act - call the action method
            ViewResult result = target.Index();

            // Assert - check the result
            Assert.AreEqual("Hello", result.ViewBag.Message);
        }

        [TestMethod]
        public void RedirectTest() {
            // Arrange - create the controller
            ExampleController target = new ExampleController();

            // Act - call the action method
            RedirectResult result = target.Redirect();

            // Assert - check the result
            Assert.IsTrue(result.Permanent);
            Assert.AreEqual("/Example/Index", result.Url);
        }

        [TestMethod]
        public void RedirectValueTest() {

            // Arrange - create the controller
            ExampleController target = new ExampleController();

            // Act - call the action method
            RedirectToRouteResult result = target.RedirectToRoute();

            // Assert - check the result
            Assert.IsFalse(result.Permanent);    

            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("MyID", result.RouteValues["ID"]);
        }

        [TestMethod]
        public void StatusCodeResultTest() {

            // Arrange - create the controller
            ExampleController target = new ExampleController();

            // Act - call the action method
            HttpStatusCodeResult result = target.StatusCode();

            // Assert - check the result
            Assert.AreEqual(401, result.StatusCode);
        }
    }
}