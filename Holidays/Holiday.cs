using System;
using System.Collections.Generic;

namespace BusinessDayCounting.Holidays
{
    public class Holiday
    {
        public DateTime FirstTime { get; protected set; }
        public int NumberOfDays { get; protected set; }
        public HolidayRecurrance Recurrance { get; protected set; }
        public bool SubstituteWeekendOccurances { get; protected set; }

        public Holiday(DateTime firstTime, int numberOfDays, HolidayRecurrance recurrance = null, bool substituteWeekendOccurances = true)
        {
            FirstTime = firstTime;
            NumberOfDays = numberOfDays;
            Recurrance = recurrance ?? HolidayRecurrance.Default;
        }

        public IEnumerable<DateTime> GetForYear(int year)
        {
            return Recurrance.GetForYear(this, year);
        }
    }
}