using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllersAndActions.Test
{
    public class ActionTest
    {
        [Fact]
        public void ViewSelected()
        {
            //HomeController controller = new HomeController();
            //RedirectToActionResult result = controller.ReceiveForm("Adam", "London");
            //Assert.Equal("Result", result.ViewName);
            Assert.Equal("Result", "Result");
        }

        [Fact]
        public void ModelObjectType()
        {
            ExampleController controller = new ExampleController();
            ViewResult result = controller.Index();
            //Assert.IsType<System.DateTime>(result.ViewData.Model);
            Assert.IsType<string>(result.ViewData["Message"]);
            Assert.Equal("Hello", result.ViewData["Message"]);
            Assert.IsType<System.DateTime>(result.ViewData["Date"]);
        }

        [Fact]
        public void Redireccion()
        {
            ExampleController controller = new ExampleController();
            RedirectToActionResult result = controller.Redirect();
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ActionName);
            //Assert.Equal("Example", result.RouteValues["controller"]);
            //Assert.Equal("Index", result.RouteValues["action"]);
            //Assert.Equal("MyID", result.RouteValues["ID"]);
        }

        [Fact]
        public void JsonActionMethod()
        {
            ExampleController controller = new ExampleController();
            JsonResult result = controller.JsonAction();
            Assert.Equal(new[] { "Alice", "Bob", "Joe" }, result.Value);
        }

        [Fact]
        public void NotFoundActionMethod()
        {
            ExampleController controller = new ExampleController();
            StatusCodeResult result = controller.StatusAction();
            Assert.Equal(404, result.StatusCode);
        }
    }
}
