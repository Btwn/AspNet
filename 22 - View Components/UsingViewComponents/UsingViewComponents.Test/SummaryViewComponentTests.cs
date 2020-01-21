﻿using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections.Generic;
using Moq;
using UsingViewComponents.Models;
using UsingViewComponents.Components;
using Xunit;

namespace UsingViewComponents.Test
{
    public class SummaryViewComponentTests
    {
        [Fact]
        public void TestSummary()
        {
            var mockRepository = new Mock<ICityRepository>();
            mockRepository.SetupGet(m => m.Cities).Returns(new List<City>
            {
                new City { Population = 100 },
                new City { Population = 20000 },
                new City { Population = 1000000 },
                new City { Population = 500000 }
            });

            var viewComponent = new CitySummary(mockRepository.Object);
            ViewViewComponentResult result = viewComponent.Invoke(false) as ViewViewComponentResult;

            Assert.IsType<CityViewModel>(result.ViewData.Model);
            Assert.Equal(4, ((CityViewModel)result.ViewData.Model).Cities);
            Assert.Equal(1520100, ((CityViewModel)result.ViewData.Model).Population);
        }
    }
}
