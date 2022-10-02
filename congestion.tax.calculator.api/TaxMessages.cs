using System;
namespace congestion.tax.calculator.api
{
    public static class TaxMessages
    {
        public const string MsgTollFreeVehicle = " Toll tax exempt vehicles.";
        public const string MsgSucessMessage = "Toll tax calculated sucessfully.";

        public static string MsgDiffDates = " Tax calculation datetime should be on same date. Different dates are:";

        public static string InvalidVehicle = "Invalid vehicle Type";
    }
}
