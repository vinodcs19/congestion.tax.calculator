using System;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public interface ICongestionTaxCalculator
    {
        Task<int> GetTax(IVehicle vehicle, DateTime[] dates);
        Task<bool> IsTollFreeVehicle(IVehicle vehicle);
        Task<int> GetTollFee(DateTime date, IVehicle vehicle);
        Task<bool> IsTollFreeDate(DateTime date);
        Task<bool> IsTollFreeDateDayBeforeHoliday(DateTime date);
    }
}
