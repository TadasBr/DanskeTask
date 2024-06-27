namespace Tadas_Brazaitis_Danske.Utility.Constants
{
    public static class CreditDecisionConstants
    {
        public static readonly double MinCreditAmount = 2000;
        public static readonly double MaxCreditAmount = 69000;

        public static readonly InterestRateByFutureDebt[] interestRateByFutureDebts =
        [ 
            new InterestRateByFutureDebt(0, 20000, 3),
            new InterestRateByFutureDebt(20000, 39000, 4),
            new InterestRateByFutureDebt(40000, 59000, 5),
            new InterestRateByFutureDebt(60000, int.MaxValue, 6)
        ];
    }

    public class InterestRateByFutureDebt
    {
        public InterestRateByFutureDebt(double iutureDebtFrom, double iutureDebtTo, double interestRate)
        {
            FutureDebtFrom = iutureDebtFrom;
            FutureDebtTo = iutureDebtTo;
            InterestRate = interestRate;           
        }

        public double FutureDebtFrom { get; set; }

        public double FutureDebtTo { get; set; }

        public double InterestRate { get; set; }
    }
}
