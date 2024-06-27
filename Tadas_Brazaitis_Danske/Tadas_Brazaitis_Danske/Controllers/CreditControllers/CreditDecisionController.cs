using Microsoft.AspNetCore.Mvc;
using Tadas_Brazaitis_Danske.Models.CreditModels;
using Tadas_Brazaitis_Danske.Utility.Constants;
using Tadas_Brazaitis_Danske.Utility.UtilityFunctions;

namespace Tadas_Brazaitis_Danske.Controllers.CreditControllers
{
    [Route("api/credit-decision")]
    [ApiController]
    public class CreditDecisionController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("get-credit-decision")]
        public IActionResult GetCreditDecision([FromBody] CreditDecisionDTO creditDecisionData)
        {
            if (creditDecisionData.CreditAmount < 0 || creditDecisionData.PreexistingCreditAmount < 0)
            {
                return BadRequest("Credit amounts can not be negative.");
            }

            if (creditDecisionData.Term != null && creditDecisionData.Term < 0)
            {
                return BadRequest("Term can not be negative.");
            }

            bool decision = creditDecisionData.CreditAmount > CreditDecisionConstants.MinCreditAmount &&
                            creditDecisionData.CreditAmount < CreditDecisionConstants.MaxCreditAmount;
            
            if (!decision)
            {
                return Ok(new CreditDecisionResponseDTO(false, 0));
            }

            double interestRate;
            try
            {
                interestRate = CreditDecisionUtilityFunctions.GetInterestRateByTotalCreditAmount(
                    creditDecisionData.CreditAmount, creditDecisionData.PreexistingCreditAmount);
            }
            catch
            {
                return BadRequest("An error occured while calculating interest rate, please contact: support@ourbank.com");
            }

            CreditDecisionResponseDTO response = new(decision, interestRate);

            return Ok(response);
        }
    }
}
