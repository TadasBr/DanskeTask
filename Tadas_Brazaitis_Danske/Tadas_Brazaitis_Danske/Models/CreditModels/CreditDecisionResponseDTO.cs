using System.ComponentModel.DataAnnotations;

namespace Tadas_Brazaitis_Danske.Models.CreditModels
{
    public class CreditDecisionResponseDTO
    {
        public CreditDecisionResponseDTO(bool decision, double interestRate)
        {
            Decision = decision;
            InterestRate = interestRate;
        }

        [Required]
        public bool Decision { get; set; }

        [Required]
        public double InterestRate { get; set; }
    }
}
