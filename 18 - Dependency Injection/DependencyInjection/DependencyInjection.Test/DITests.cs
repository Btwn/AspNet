using DependencyInjection.Controllers;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DependencyInjection.Test
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(data);
            //HomeController controller = new HomeController { Repository = mock.Object };
            //TypeBroker.SetTestObject(mock.Object);
            HomeController controller = new HomeController(mock.Object);
            ViewResult result = controller.Index();
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
