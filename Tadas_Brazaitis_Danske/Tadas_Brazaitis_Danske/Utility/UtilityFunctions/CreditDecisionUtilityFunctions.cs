using Tadas_Brazaitis_Danske.Utility.Constants;

namespace Tadas_Brazaitis_Danske.Utility.UtilityFunctions
{
    public static class CreditDecisionUtilityFunctions
    {
        /// <summary>
        /// Calculates the interest rate based on the total credit amount
        /// </summary>
        /// <param name="creditAmount">The required credit amount requested by the user.</param>
        /// <param name="preexistingCreditAmount">The user's preexisting credit amount.</param>
        /// <returns>The interest rate applicable to the total credit amount.</returns>
        /// <exception cref="ArgumentException">Thrown when the total credit amount does not fall into any predefined interest rate range.</exception>
        public static double GetInterestRateByTotalCreditAmount(double creditAmount, double preexistingCreditAmount)
        {
            double totalAmount = creditAmount + preexistingCreditAmount;

            InterestRateByFutureDebt[] interestRateByFutureDebts = CreditDecisionConstants.interestRateByFutureDebts;
            int interestRateByFutureDebtsLength = interestRateByFutureDebts.Length;

            for (int i = 0; i < interestRateByFutureDebtsLength; i++)
            {
                if (i == 0 || i == interestRateByFutureDebtsLength - 1)
                {
                    if (interestRateByFutureDebts[i].FutureDebtFrom < totalAmount && interestRateByFutureDebts[i].FutureDebtTo > totalAmount)
                    {
                        return interestRateByFutureDebts[i].InterestRate;
                    }
                }
                else
                {
                    if (interestRateByFutureDebts[i].FutureDebtFrom <= totalAmount && interestRateByFutureDebts[i].FutureDebtTo >= totalAmount)
                    {
                        return interestRateByFutureDebts[i].InterestRate;
                    }
                }
            }

            throw new ArgumentException("Total credit amount does not fall into any interest rate range.");
        }
    }
}
