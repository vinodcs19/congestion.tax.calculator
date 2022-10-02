namespace congestion.tax.calculator.api
{
    public class TollTaxResponse
    {
        public int StatusCode { get; set; }
        public string VehicleType { get; set; }
        public int TotalCongestionTax { get; set; }
        public string ErrorMessage { get; set; }
        public string SucessMessage { get; set; }
    }
}
