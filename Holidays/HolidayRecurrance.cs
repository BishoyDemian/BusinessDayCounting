using System;
using System.Collections.Generic;

namespace BusinessDayCounting.Holidays
{
    public abstract class HolidayRecurrance
    {
        public bool SubstituteWeekends { get; private set; }

        protected HolidayRecurrance(bool substituteWeekends = true)
        {
            SubstituteWeekends = substituteWeekends;
        }

        public static HolidayRecurrance Default { get { return new FixedDateRecurrance(true);} }
        public abstract IEnumerable<DateTime> GetForYear(Holiday holiday, int year);
    }
}
