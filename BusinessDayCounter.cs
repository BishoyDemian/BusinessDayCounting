using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessDayCounting
{
    public class BusinessDayCounter
    {
        /// <summary>
        /// TASK ONE:
        /// Calculates the number of weekdays in between two dates.
        /// </summary>
        /// <remarks>
        /// Weekdays are Monday, Tuesday, Wednesday, Thursday, Friday.
        /// The returned count should not include either firstDate or secondDate - e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
        /// If secondDate is equal to or before firstDate, return 0.
        /// </remarks>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <returns>Number of weekdays</returns>
        public static int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            return 0;
        }

        /// <summary>
        /// TASK TWO:
        /// Calculates the number of business days in between two dates.
        /// </summary>
        /// <remarks>
        /// Business days are Monday, Tuesday, Wednesday, Thursday, Friday, but excluding any dates which appear in the supplied list of public holidays.
        /// The returned count should not include either firstDate or secondDate - e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
        /// If secondDate is equal to or before firstDate, return 0.
        /// </remarks>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <param name="publicHolidays">List of public holidays.</param>
        /// <returns>Number of business days</returns>
        public static int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            return 0;
        }


    }
}
