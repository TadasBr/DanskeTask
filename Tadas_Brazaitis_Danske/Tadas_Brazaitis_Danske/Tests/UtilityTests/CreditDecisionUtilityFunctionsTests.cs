using Tadas_Brazaitis_Danske.Utility.Constants;
using Tadas_Brazaitis_Danske.Utility.UtilityFunctions;
using Xunit;

namespace Tadas_Brazaitis_Danske.Tests.UtilityTests
{
    public class CreditDecisionUtilityFunctionsTests
    {
         [Fact]
         public void GetInterestRateByTotalCreditAmount_ShouldReturnCorrectInterestRate_ForValidRanges()
         {
             // Arrange
             double creditAmount = CreditDecisionConstants.interestRateByFutureDebts[1].FutureDebtFrom;
             double preexistingCreditAmount = 0;

             // Act
             double interestRate = CreditDecisionUtilityFunctions.GetInterestRateByTotalCreditAmount(creditAmount, preexistingCreditAmount);

             // Assert
             Assert.Equal(CreditDecisionConstants.interestRateByFutureDebts[1].InterestRate, interestRate);
         }

        [Fact]
        public void GetInterestRateByTotalCreditAmount_ShouldReturnIncorrectInterestRate_ForInvalidRanges()
        {
            // Arrange
            double creditAmount = CreditDecisionConstants.interestRateByFutureDebts[1].FutureDebtFrom;
            double preexistingCreditAmount = 0;

            // Act
            double interestRate = CreditDecisionUtilityFunctions.GetInterestRateByTotalCreditAmount(creditAmount, preexistingCreditAmount);

            // Assert
            Assert.NotEqual(CreditDecisionConstants.interestRateByFutureDebts[2].InterestRate, interestRate);
        }
    }
}
