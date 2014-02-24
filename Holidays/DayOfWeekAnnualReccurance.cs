using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessDayCounting.Holidays
{
    public sealed class DayOfWeekAnnualReccurance : HolidayRecurrance
    {
        public DayOfWeek DayOfWeek { get; protected set; }

        public WeekOfMonth Week { get; protected set; }

        public Month Month { get; protected set; }

        public DayOfWeekAnnualReccurance(DayOfWeek dayOfWeek, WeekOfMonth week, Month month, bool substituteWeekend = true)
            :base(substituteWeekend)
        {
            DayOfWeek = dayOfWeek;
            Week = week;
            Month = month;
        }

        public override IEnumerable<DateTime> GetForYear(Holiday holiday, int year)
        {
            if (year < DateTime.MinValue.Year)
                throw new ArgumentOutOfRangeException("year", "value for year is below the minimum value");

            var firstDayInMonth = new DateTime(year, (int) Month, 1);

            var days = firstDayInMonth.AllDaysInTheMonth();

            var firstHolidayDay = days.FirstOrDefault(d => d.DayOfWeek == DayOfWeek && d.WeekOfMonth() == (int) Week);

            if (firstHolidayDay == default(DateTime))
                yield break; // we could not find that recurrance for the given year

            int count = 0;
            int daysFilled = 0;
            while (daysFilled < holiday.NumberOfDays)
            {
                var date = firstHolidayDay.AddDays(count);
                count++;

                if (SubstituteWeekends && date.IsWeekend())
                    continue;

                daysFilled++;
                yield return date;
            }
        }
    }
}