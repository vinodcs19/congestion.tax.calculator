using System;
using System.Linq;
using System.Threading.Tasks;
using congestion.calculator;
using congestion.tax.calculator.api.Interfaces;
using Microsoft.Extensions.Logging;
using static CongestionTaxCalculator;

namespace congestion.tax.calculator.api.Services
{
    public class TollTaxCalculatorService: ITollTaxCalculatorService
    {
        private readonly ILogger<TollTaxCalculatorService> _logger;
        private readonly ICongestionTaxCalculator _congestionTaxCalculator;

        public TollTaxCalculatorService(ILogger<TollTaxCalculatorService> logger, ICongestionTaxCalculator congestionTaxCalculator) =>
            (_logger, _congestionTaxCalculator) = (logger, congestionTaxCalculator);
       

        public async Task<TollTaxResponse> CalculateTollTax(TollTaxRequest tollTaxRequest)
        {
            _logger.LogInformation($"Request processing start at {DateTime.UtcNow}");
            // checking for Tax Exempt vehicles 
            if (Enum.IsDefined(typeof(TollFreeVehicles), tollTaxRequest.VehicleType))
            {
                return  new TollTaxResponse(){
                    ErrorMessage = null,
                    StatusCode = 200,
                    TotalCongestionTax = 0,
                    VehicleType = tollTaxRequest.VehicleType,
                    SucessMessage = TaxMessages.MsgTollFreeVehicle

                };
            }

            var taxVehicle = GetTaxvehicleType(tollTaxRequest.VehicleType);

            if(taxVehicle == null)
            {
                return new TollTaxResponse()
                {
                    ErrorMessage = TaxMessages.InvalidVehicle,
                    StatusCode = 400,
                    TotalCongestionTax = 0,
                    VehicleType = tollTaxRequest.VehicleType,
                    SucessMessage = null

                };

            }
           var checkDate = tollTaxRequest.DateTimes.GroupBy(x => x.ToShortDateString());

            //// check for different dates are in request
            if (checkDate.Count() > 1)
            {
                var differentDates = String.Join(';' , checkDate.Select(x=>x.Key));
                return new TollTaxResponse()
                {
                    ErrorMessage = $"{TaxMessages.MsgDiffDates} {differentDates}",
                    StatusCode = 400,
                    TotalCongestionTax = 0,
                    VehicleType = tollTaxRequest.VehicleType,
                    SucessMessage = null

                };

            }

            var result = await _congestionTaxCalculator.GetTax(taxVehicle, tollTaxRequest.DateTimes) ;

            return new TollTaxResponse()
            {
                ErrorMessage = null,
                StatusCode = 200,
                TotalCongestionTax = result,    
                VehicleType = tollTaxRequest.VehicleType,
                SucessMessage = TaxMessages.MsgSucessMessage

            }; 
        }

        private IVehicle GetTaxvehicleType(string vehicleType)
        {
            switch (vehicleType.ToLower())
            {
                case "car":
                    return new Car();
                     
                default:
                    return null;
            }
        }
       
    }
}
