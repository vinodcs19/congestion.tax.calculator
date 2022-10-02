using System;
using System.Linq;
using System.Threading.Tasks;
using congestion.calculator;


public class CongestionTaxCalculator: ICongestionTaxCalculator
{

    public static readonly int MaximumTaxFee = 60;

    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */

    public async Task<int> GetTax(IVehicle vehicle, DateTime[] dates)
    {
        var totalTaxFee = 0;

       
        if ( await IsTollFreeVehicle(vehicle)) return await Task.FromResult(totalTaxFee);

        var inputSortedDateTime = dates.OrderBy(t => t).ToArray(); 
        var intervalStartDatetime = inputSortedDateTime[0];

        var intervalStartTime = intervalStartDatetime.TimeOfDay;

        var tempTaxFee =  await GetTollFee(intervalStartDatetime , vehicle);

        foreach (DateTime dateTime in inputSortedDateTime)
        {
            int nextTaxFee = await GetTollFee(dateTime, vehicle);

            //long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            //long minutes = diffInMillies / 1000 / 60;

            //if (minutes <= 60)
            //{
            //    if (totalFee > 0) totalFee -= tempFee;
            //    if (nextFee >= tempFee) tempFee = nextFee;
            //    totalFee += tempFee;
            //}
            //else
            //{
            //    totalFee += nextFee;
            //}

            if ((dateTime.TimeOfDay - intervalStartTime).TotalMinutes <= 60)
            {
                if (nextTaxFee >= tempTaxFee)
                {
                    if (totalTaxFee > 0) totalTaxFee -= tempTaxFee;
                    tempTaxFee = nextTaxFee;
                }
                totalTaxFee += tempTaxFee;  
            }
            else
            {
                totalTaxFee += nextTaxFee;
                if (totalTaxFee >= MaximumTaxFee) break; // To avoid unnecessary calculation 
                intervalStartTime = dateTime.TimeOfDay;// set new interval time for next hour
                tempTaxFee = nextTaxFee; 
            }

        }
        //if (totalFee > 60) totalFee = 60;
        return await Task.FromResult(Math.Min(totalTaxFee, MaximumTaxFee)); ;
    }

    public async Task<bool> IsTollFreeVehicle(IVehicle vehicle)
    {
        if (vehicle == null) return  await Task.FromResult(false);
        var vehicleType = vehicle.GetVehicleType();
        //return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
        //       vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
        //       vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
        //       vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
        //       vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
        //       vehicleType.Equals(TollFreeVehicles.Military.ToString());

        return await Task.FromResult(Enum.IsDefined(typeof(TollFreeVehicles), vehicleType));
    }

    public async Task<int> GetTollFee(DateTime date, IVehicle vehicle)
    {
        if (await IsTollFreeDate(date) || await IsTollFreeDateDayBeforeHoliday(date.AddDays(1))) return await Task.FromResult(0);

        int hour = date.Hour;
        int minute = date.Minute;

        if (hour == 6 && minute >= 0 && minute <= 29) return  await Task.FromResult(8);
        else if (hour == 6 && minute >= 30 && minute <= 59) return await Task.FromResult(13);
        else if (hour == 7 && minute >= 0 && minute <= 59) return await Task.FromResult(18);
        else if (hour == 8 && minute >= 0 && minute <= 29) return await Task.FromResult(13);
        else if (hour == 8 && minute >= 30 && minute <= 59) return await Task.FromResult(8);
        else if (hour >= 9 && hour <= 14 && minute >= 00 && minute <= 59) return await Task.FromResult(8);
        else if (hour == 15 && minute >= 00 && minute <= 29) return await Task.FromResult(13);
        else if (hour == 15 && minute >= 30 || hour == 16 && minute <= 59) return await Task.FromResult(18);
        else if (hour == 17 && minute >= 0 && minute <= 59) return await Task.FromResult(13);
        else if (hour == 18 && minute >= 0 && minute <= 29) return await Task.FromResult(8);
        else return await Task.FromResult(0);
    }

    public async Task<bool> IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return await Task.FromResult(true);

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return  await Task.FromResult(true);
            }
           
        }
        return await Task.FromResult(false);
    }

    public async Task<bool> IsTollFreeDateDayBeforeHoliday(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return await Task.FromResult(true);
            }

        }
        return await Task.FromResult(false);
    }

    public enum TollFreeVehicles
    {
        Emergency = 0,
        Busses = 1,
        Diplomat = 2,
        Motorcycles = 3,
        Military = 4,
        Foreign = 5
    }
}