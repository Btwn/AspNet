using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using _06WorkingWhitVisualStudio.Models;

namespace _06WorkingWhitVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            //Arrange
            var p = new Product { Name = "Test", Price = 100M };

            //Act
            p.Name = "New Name";

            //Assert
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            //Arrange
            var p = new Product { Name = "Test", Price = 100M };

            // Act
            p.Price = 200;

            //Assert
            Assert.Equal(200M, p.Price);
        }
    }
}
