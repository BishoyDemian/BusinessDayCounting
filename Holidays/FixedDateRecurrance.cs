using System;
using System.Collections.Generic;

namespace BusinessDayCounting.Holidays
{
    public sealed class FixedDateRecurrance : HolidayRecurrance
    {
        public FixedDateRecurrance(bool substituteWeekends):base(substituteWeekends)
        {
        }

        public override IEnumerable<DateTime> GetForYear(Holiday holiday, int year)
        {
            if (year < DateTime.MinValue.Year)
                throw new ArgumentOutOfRangeException("year", "value for year is below the minimum value");

            var daysInMonthThisYear = DateTime.DaysInMonth(year, holiday.FirstTime.Month);
            if (holiday.FirstTime.Day > daysInMonthThisYear)
                yield break;

            var firstDayThisYear = new DateTime(year, holiday.FirstTime.Month, holiday.FirstTime.Day);
            
            int count = 0;
            int daysFilled = 0;
            while (daysFilled < holiday.NumberOfDays)
            {
                var date = firstDayThisYear.AddDays(count);
                count++;

                if (SubstituteWeekends && date.IsWeekend())
                    continue;

                yield return date;
                daysFilled++;
            }
        }
    }
}