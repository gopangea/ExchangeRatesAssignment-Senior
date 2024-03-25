using ExchangeRatesAssignment.Api.Controllers;
using ExchangeRatesAssignment.Api.Models;
using ExchangeRatesAssignment.Api.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatesAssignment.UnitTests
{
    public class ExchangeRateServiceTests
    {
        private List<PartnerRate> partnerRates;

        public ExchangeRateServiceTests()
        {
            partnerRates = new List<PartnerRate>() {
                new PartnerRate() {
                    Currency = "MXN",
                    PaymentMethod = "debit",
                    DeliveryMethod = "cash",
                    Rate= 16.65m,
                    AcquiredDate = DateTime.Parse("2023-07-26T05:00:00.000Z")}
                ,
                new PartnerRate()
                {
                    Currency = "MXN",
                    PaymentMethod = "bankaccount",
                    DeliveryMethod = "deposit",
                    Rate= 16.89m,
                    AcquiredDate = DateTime.Parse("2023-07-24T05:00:00.000Z"),
                },
                new PartnerRate(){
                    Currency = "INR",
                    PaymentMethod = "debit",
                    DeliveryMethod = "cash",
                    Rate = 81.63m,
                    AcquiredDate = DateTime.Parse("2023-07-24T05:00:00.000Z")
                },
                new PartnerRate() {
                    Currency = "INR",
                    PaymentMethod = "debit",
                    DeliveryMethod = "cash",
                    Rate = 81.72m,
                    AcquiredDate = DateTime.Parse("2023-07-26T05:00:00.000Z")
                },
                new PartnerRate()
                {
                     Currency = "GTQ",
                      PaymentMethod = "debit",
                      DeliveryMethod = "deposit",
                      Rate = 8.26m,
                      AcquiredDate = DateTime.Parse("2023-07-24T05:00:00.000Z")
                }
            };
        }

        [Fact]
        public void ExchangeRateServiceTest_OneObject_IsEqual()
        {
            //Arrange
            var mockPartnerRateService = new Mock<PartnerRateService>();
            mockPartnerRateService.CallBase = true;
            mockPartnerRateService.Setup(p => p.GetPartnerRates()).Returns(partnerRates);

            var exchangRateService = new ExchangeRateService(mockPartnerRateService.Object);

            //Act
            var result = exchangRateService.GetExchangeRates("GTM").ToList();

            //Assert
            var expected = new List<ExchangeRate>()
            {
                new ExchangeRate ("GTQ", "GTM", "debit", "deposit", 0.056m, 8.26m)
            };
            expected.Should().BeEquivalentTo(result);
        }


        [Fact]
        public void ExchangeRateServiceTest_DuplicateObject_IsEqual()
        {
            //Arrange
            var mockPartnerRateService = new Mock<PartnerRateService>();
            mockPartnerRateService.CallBase = true;
            mockPartnerRateService.Setup(p => p.GetPartnerRates()).Returns(partnerRates);

            var exchangRateService = new ExchangeRateService(mockPartnerRateService.Object);

            //Act
            var result = exchangRateService.GetExchangeRates("IND").ToList();

            //Assert
            var expected = new List<ExchangeRate>()
            {
                new ExchangeRate ("INR", "IND", "debit", "cash", 3.213m, 81.72m)
            };
            expected.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void ExchangeRateServiceTest_TwoObjects_IsEqual()
        {
            //Arrange
            var mockPartnerRateService = new Mock<PartnerRateService>();
            mockPartnerRateService.CallBase = true;
            mockPartnerRateService.Setup(p => p.GetPartnerRates()).Returns(partnerRates);

            var exchangRateService = new ExchangeRateService(mockPartnerRateService.Object);

            //Act
            var result = exchangRateService.GetExchangeRates("MEX").ToList();

            //Assert
            var expected = new List<ExchangeRate>()
            {
                new ExchangeRate ("MXN", "MEX", "debit", "cash", 0.024m, 16.65m),
                new ExchangeRate ("MXN", "MEX", "bankaccount", "deposit", 0.024m, 16.89m)
            };
            expected.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void ExchangeRateServiceTest_NoObjects_IsEqual()
        {
            //Arrange
            var mockPartnerRateService = new Mock<PartnerRateService>();
            mockPartnerRateService.CallBase = true;
            mockPartnerRateService.Setup(p => p.GetPartnerRates()).Returns(partnerRates);

            var exchangRateService = new ExchangeRateService(mockPartnerRateService.Object);

            //Act
            var result = exchangRateService.GetExchangeRates("XXX").ToList();

            //Assert
            var expected = new List<ExchangeRate>() { };
            expected.Should().BeEquivalentTo(result);
        }
    }
}

