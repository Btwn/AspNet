using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using _06WorkingWhitVisualStudio.Controllers;
using _06WorkingWhitVisualStudio.Models;
using Xunit;


namespace _06WorkingWhitVisualStudio.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionModellsComplete()
        {
            //Arrange
            var controller = new HomeController();
            

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            
            //Assert
            Assert.Equal(SimpleRepository.SharedRepository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
