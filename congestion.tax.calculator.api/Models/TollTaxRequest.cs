using System;
namespace congestion.tax.calculator.api
{
    public class TollTaxRequest
    {
        public string VehicleType { get; set; }
        public DateTime[] DateTimes { get; set; }
    }
}
