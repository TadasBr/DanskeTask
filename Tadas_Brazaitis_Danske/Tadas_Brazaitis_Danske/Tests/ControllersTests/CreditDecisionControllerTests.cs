using Xunit;
using Microsoft.AspNetCore.Mvc;
using Tadas_Brazaitis_Danske.Controllers.CreditControllers;
using Tadas_Brazaitis_Danske.Utility.Constants;
using Tadas_Brazaitis_Danske.Models.CreditModels;

namespace Tadas_Brazaitis_Danske.Tests.ControllersTests
{
    public class CreditDecisionControllerTests
    {
        private readonly CreditDecisionController _controller;

        public CreditDecisionControllerTests()
        {
            _controller = new CreditDecisionController();
        }

        [Fact]
        public void GetCreditDecision_ReturnsBadRequest_WhenCreditAmountIsNegative()
        {
            // Arrange
            var dto = new CreditDecisionDTO(-100, 12, 1000);

            // Act
            var result = _controller.GetCreditDecision(dto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Credit amounts can not be negative.", badRequestResult.Value);
        }

        [Fact]
        public void GetCreditDecision_ReturnsBadRequest_WhenPreexistingCreditAmountIsNegative()
        {
            // Arrange
            var dto = new CreditDecisionDTO(1000, 12, -1000);

            // Act
            var result = _controller.GetCreditDecision(dto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Credit amounts can not be negative.", badRequestResult.Value);
        }

        [Fact]
        public void GetCreditDecision_ReturnsBadRequest_WhenTermIsNegative()
        {
            // Arrange
            var dto = new CreditDecisionDTO(1000, -12, 1000);

            // Act
            var result = _controller.GetCreditDecision(dto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Term can not be negative.", badRequestResult.Value);
        }

        [Fact]
        public void GetCreditDecision_ReturnsOk_WithCorrectDecisionAndInterestRate()
        {
            // Arrange
            var dto = new CreditDecisionDTO((int)CreditDecisionConstants.interestRateByFutureDebts[1].FutureDebtTo, 12, 0);

            // Act
            var result = _controller.GetCreditDecision(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<CreditDecisionResponseDTO>(okResult.Value);

            Assert.True(response.Decision);
            Assert.Equal(CreditDecisionConstants.interestRateByFutureDebts[1].InterestRate, response.InterestRate);
        }

        [Fact]
        public void GetCreditDecision_ReturnsOk_WithCorrectDecisionAndIncorrectInterestRate()
        {
            // Arrange
            var dto = new CreditDecisionDTO((int)CreditDecisionConstants.interestRateByFutureDebts[0].FutureDebtTo, 12, 0);

            // Act
            var result = _controller.GetCreditDecision(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<CreditDecisionResponseDTO>(okResult.Value);

            Assert.True(response.Decision);
            Assert.NotEqual(CreditDecisionConstants.interestRateByFutureDebts[0].InterestRate, response.InterestRate);
        }

        [Fact]
        public void GetCreditDecision_ReturnsOk_WithIncorrectDecision()
        {
            // Arrange
            var dto = new CreditDecisionDTO((int)CreditDecisionConstants.interestRateByFutureDebts[0].FutureDebtTo, 12, 0);

            // Act
            var result = _controller.GetCreditDecision(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<CreditDecisionResponseDTO>(okResult.Value);

            Assert.True(response.Decision);
            Assert.NotEqual(0, response.InterestRate);
        }
    }
}
