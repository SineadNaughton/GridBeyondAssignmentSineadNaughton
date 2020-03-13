using GridBeyondAssignmentSineadNaughton.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GridBeyondAssignmentSineadNaughton.Test
{
    [TestClass]
    public class PriceCalculationsHelperTest
    {
        List<PriceItem> priceItems = new List<PriceItem>()
        {
            new PriceItem(){Id=1, Price=50, Timestamp=DateTime.Parse("10/01/2013 0:30")},
            new PriceItem(){Id=2, Price=50, Timestamp=DateTime.Parse("10/01/2013 1:00")},
            new PriceItem(){Id=3, Price=40.88m, Timestamp=DateTime.Parse("10/01/2013 1:30")},
            new PriceItem(){Id=4, Price=40.88m, Timestamp=DateTime.Parse("10/01/2013 2:00")},
            new PriceItem(){Id=5, Price=37.46m, Timestamp=DateTime.Parse("10/01/2013 2:30")},
            new PriceItem(){Id=6, Price=75, Timestamp=DateTime.Parse("10/01/2013 3:00")},
            new PriceItem(){Id=7, Price=36.64m, Timestamp=DateTime.Parse("10/01/2013 3:30")}
        };

        [TestMethod]
        public void GetMinPriceTest()
        {
            //Arrange
            decimal expected = 36.64m;
            PriceCalculationsHelper priceCalculationsHelper = new PriceCalculationsHelper();

            //Act
            decimal actual = priceCalculationsHelper.GetMinPrice(priceItems);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxPriceTest()
        {
            //Arrange
            decimal expected = 75;
            PriceCalculationsHelper priceCalculationsHelper = new PriceCalculationsHelper();

            //Act
            decimal actual = priceCalculationsHelper.GetMaxPrice(priceItems);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAvgPriceTest()
        {
            //Arrange
            decimal expected = 47.27m;
            PriceCalculationsHelper priceCalculationsHelper = new PriceCalculationsHelper();

            //Act
            decimal actual = priceCalculationsHelper.GetAvgPrice(priceItems);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMostExpensiveSixtyMinutesPeriodTest()
        {
            //Arrange
            string expected = "10/01/2013 02:00:00 to 10/01/2013 03:00:00";
            PriceCalculationsHelper priceCalculationsHelper = new PriceCalculationsHelper();

            //Act
            string actual = priceCalculationsHelper.GetMostExpensiveSixtyMinutesPeriod(priceItems);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
