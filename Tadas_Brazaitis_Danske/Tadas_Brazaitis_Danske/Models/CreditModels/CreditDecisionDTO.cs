using System.ComponentModel.DataAnnotations;

namespace Tadas_Brazaitis_Danske.Models.CreditModels
{
    public class CreditDecisionDTO
    {
        public CreditDecisionDTO(int creditAmount, int? term, double preexistingCreditAmount)
        {
            CreditAmount = creditAmount;
            Term = term;
            PreexistingCreditAmount = preexistingCreditAmount;
        }

        [Required]
        public int CreditAmount { get; set; }

        public int? Term { get; set; }

        [Required]
        public double PreexistingCreditAmount { get; set; }
    }
}
