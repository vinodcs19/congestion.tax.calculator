using System.Threading.Tasks;
using congestion.tax.calculator.api.Interfaces;
using congestion.tax.calculator.api.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace congestion.tax.calculator.api.Controllers
{
    [ApiController]
    public class TollTaxCalculatorController : ControllerBase
    {
        private readonly ILogger<TollTaxCalculatorController> _logger;
        private readonly ITollTaxCalculatorService _tollTaxCalculatorService;

        public TollTaxCalculatorController(ILogger<TollTaxCalculatorController> logger, ITollTaxCalculatorService tollTaxCalculatorService) =>
            (_logger, _tollTaxCalculatorService) = (logger, tollTaxCalculatorService);

        /// <summary>
        /// Toll tax calculation post request
        /// </summary>
        /// <param name="tollTaxRequest"></param>
        
        [HttpPost]
        [Route("v1/tolltaxcalculator")]
       
        public async Task<IActionResult> TollTaxCalculator([FromBody] TollTaxRequest tollTaxRequest)
        {
            var validationResult = new TaxRequestValidator().Validate(tollTaxRequest);
            if (validationResult.IsValid)
            {

                var result = await _tollTaxCalculatorService.CalculateTollTax(tollTaxRequest);
                switch (result.StatusCode)
                {
                    case 200:
                      return Ok(result);
                    case 400:
                        return BadRequest(result);
                    
                }
            }
            return BadRequest(validationResult);
        }
    }
}
