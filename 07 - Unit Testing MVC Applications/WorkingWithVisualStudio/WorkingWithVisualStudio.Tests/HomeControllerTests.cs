using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using Moq;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        class ModelCompleteFakeRepository : IRepository
        {
            //public IEnumerable<Product> Products { get; } = new Product[] {
            //    new Product { Name = "P1", Price = 275M },
            //    new Product { Name = "P2", Price = 48.95M },
            //    new Product { Name = "P3", Price = 19.50M },
            //    new Product { Name = "P3", Price = 34.95M }};
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
                // do nothing - not required for test
            }
        }

        [Theory]
        //[InlineData(275, 48.95, 19.50, 24.95)]
        //[InlineData(5, 48.95, 19.50, 24.95)]
        //public void IndexActionModelIsComplete(decimal price1, decimal price2, decimal price3, decimal price4)
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
            as IEnumerable<Product>;
            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        //class PropertyOnceFakeRepository : IRepository
        //{
        //    public int PropertyCounter { get; set; }
        //    public IEnumerable<Product> Products
        //    {
        //        get
        //        {
        //            PropertyCounter++;
        //            return new[] { new Product { Name = "P1", Price = 100 } };
        //        }
        //    }
        //    public void AddProduct(Product p) { }
        //}

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            //var repo = new PropertyOnceFakeRepository();
            //var controller = new HomeController { Repository = repo };
            //var result = controller.Index();
            //Assert.Equal(1, repo.PropertyCounter);
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(new[] { new Product { Name = "P1", Price = 100 } });
            var controller = new HomeController { Repository = mock.Object };
            var result = controller.Index();
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
