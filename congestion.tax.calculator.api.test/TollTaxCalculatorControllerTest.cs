using System;
using System.Threading.Tasks;
using congestion.tax.calculator.api.Controllers;
using congestion.tax.calculator.api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace congestion.tax.calculator.api.test
{
    [TestClass]
    public class TollTaxCalculatorControllerTest
    {

        private readonly Mock<ITollTaxCalculatorService> _tollTaxCalculatorServiceMock;
        private readonly TollTaxCalculatorController _tollTaxCalculatorController;


        public TollTaxCalculatorControllerTest()
        {
            var loggerMock = new Mock<ILogger<TollTaxCalculatorController>>();
            _tollTaxCalculatorServiceMock = new Mock<ITollTaxCalculatorService>();

            _tollTaxCalculatorController = new TollTaxCalculatorController(loggerMock.Object, _tollTaxCalculatorServiceMock.Object);
        }

        [TestMethod]
        public async Task  Should_return_status_code_200_on_Valid_request()
        {
            var mockData = new TollTaxResponse { StatusCode = 200 };
            var requestData = new TollTaxRequest()
            {
                VehicleType = "car",
                DateTimes = new DateTime[] { new DateTime(2013, 1, 14, 21, 0, 0) },
            };

            //Arrange
            _tollTaxCalculatorServiceMock.Setup(f => f.CalculateTollTax(It.IsAny<TollTaxRequest>())).ReturnsAsync(mockData);

            //Act
            var result = await _tollTaxCalculatorController.TollTaxCalculator(requestData);

            //Assert
            Assert.AreEqual(StatusCodes.Status200OK, ((ObjectResult)result).StatusCode);
        }

        [TestMethod]
        public async Task Should_return_status_code_400_on_InValid_request()
        {
            var mockData = new TollTaxResponse { StatusCode = 400 };
            var requestData = new TollTaxRequest();
            

            //Arrange
            _tollTaxCalculatorServiceMock.Setup(f => f.CalculateTollTax(It.IsAny<TollTaxRequest>())).ReturnsAsync(mockData);

            //Act
            var result = await _tollTaxCalculatorController.TollTaxCalculator(requestData);

            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, ((ObjectResult)result).StatusCode);
        }
    }
}
