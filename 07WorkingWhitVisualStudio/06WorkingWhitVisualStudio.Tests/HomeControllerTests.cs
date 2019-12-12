using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using _06WorkingWhitVisualStudio.Controllers;
using _06WorkingWhitVisualStudio.Models;
using Xunit;
using Moq;


namespace _06WorkingWhitVisualStudio.Tests
{
    public class HomeControllerTests
    {
        //class ModelCompleteFakeRepository : IRepository
        //{
        //    public IEnumerable<Product> Products { get; set; }
            
        //    public void AddProduct(Product p)
        //    {
        //        //do nothing - not required for test
        //    }
        //}

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void  IndexActionModelIsComplete(Product[] products)
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object }; 

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            //Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                && p1.Price == p2.Price));
        }

        //class PropertyOnceFakeRepository : IRepository
        //{
        //    public int PropertyCounter { get; set; } = 0;
        //    public IEnumerable<Product> Products
        //    {
        //        get
        //        {
        //            PropertyCounter++;
        //            return new[] { new Product { Name = "P1", Price = 100 } };
        //        }
        //    }

        //    public void AddProduct(Product p)
        //    {
        //        //do nothing - not required for test
        //    }
        //}

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
            .Returns(new[] { new Product { Name = "P1", Price = 100 } });
            var controller = new HomeController { Repository = mock.Object };

            //Act 
            var result = controller.Index();

            // Assert
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
