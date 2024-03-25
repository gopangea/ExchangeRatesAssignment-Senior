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
    public class PartnerRateServiceTests
    {
        private List<PartnerRate> partnerRates;
        private List<PartnerRate> expectedRates;

        public PartnerRateServiceTests()
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

            expectedRates = new List<PartnerRate>() {
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
        public void PartnerRateServiceTest_GetBestRates_IsEqual()
        {
            //Arrange
            var mockPartnerRateService = new Mock<PartnerRateService>();
            mockPartnerRateService.CallBase = true;
            mockPartnerRateService.Setup(p => p.GetPartnerRates()).Returns(partnerRates);

            //Act
            var result = mockPartnerRateService.Object.GetBestRates();

            //Assert
            expectedRates.Should().BeEquivalentTo(result);
        }
    }
}

