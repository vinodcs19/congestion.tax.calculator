using System;
using System.Threading.Tasks;
using congestion.calculator;
using congestion.tax.calculator.api.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace congestion.tax.calculator.api.test
{
    [TestClass]
    public class TollTaxCalculatorServiceTest
    {

        private readonly Mock<ICongestionTaxCalculator> _congestionTaxCalculatorMock;
        private readonly TollTaxCalculatorService _tollTaxCalculatorService;


        public TollTaxCalculatorServiceTest()
        {
            var loggerMock = new Mock<ILogger<TollTaxCalculatorService>>();
            _congestionTaxCalculatorMock = new Mock<ICongestionTaxCalculator>();

            _tollTaxCalculatorService = new TollTaxCalculatorService(loggerMock.Object, _congestionTaxCalculatorMock.Object);
        }

        [TestMethod]
        public async Task Should_return_tax_0_for_toll_tax_exempt_vehicles()
        {
            var requestData = new TollTaxRequest()
            {
                VehicleType = "Emergency",
                DateTimes = new DateTime[] { new DateTime(2013, 1, 14, 21, 0, 0) },
            };

            //Arrange

            //Act
            var result = await _tollTaxCalculatorService.CalculateTollTax(requestData);

            //Assert
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(0, result.TotalCongestionTax);
        }

        [TestMethod]
        public async Task Should_return_status_code_400_on_InValid_Vehicle()
        {
            var requestData = new TollTaxRequest()
            {
                VehicleType = "Test",
                DateTimes = new DateTime[] { new DateTime(2013, 1, 14, 21, 0, 0) },
            };


            //Arrange

            //Act
            var result = await _tollTaxCalculatorService.CalculateTollTax(requestData);


            //Assert
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual(0, result.TotalCongestionTax);
        }
        [TestMethod]
        public async Task Should_return_toll_tax_0_on_multipal_date_with_400()
        {
            var requestData = new TollTaxRequest()
            {
                VehicleType = "car",
                DateTimes = new DateTime[] { new DateTime(2013, 2, 14, 6, 30, 0), new DateTime(2013, 2, 15, 6, 30, 0) },
            };


            //Arrange

            //Act
            var result = await _tollTaxCalculatorService.CalculateTollTax(requestData);


            //Assert
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual(0, result.TotalCongestionTax);
        }

        [TestMethod]
        public async Task Should_return_toll_tax_on_Valid_Vehicle()
        {
            var mockData = 13;
            var requestData = new TollTaxRequest()
            {
                VehicleType = "car",
                DateTimes = new DateTime[] { new DateTime(2013, 2, 14, 6, 30, 0) },
            };


            //Arrange
            _congestionTaxCalculatorMock.Setup(f => f.GetTax( It.IsAny<Car>(), It.IsAny<DateTime[]>())).ReturnsAsync((mockData));

            //Act
            var result = await _tollTaxCalculatorService.CalculateTollTax(requestData);


            //Assert
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(13, result.TotalCongestionTax);
        }
    }
}
