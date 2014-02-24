using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessDayCounting
{
    public class BusinessDayCounter
    {
        /// <summary>
        /// Expand given 2 dates into a list of days between excluding the start and end date
        /// </summary>
        /// <returns>List of dates, each represents a single day between given dates</returns>
        private static IEnumerable<DateTime> GetDaysBetweenExeclusive(DateTime firstDate, DateTime secondDate)
        {
            if (secondDate.Date <= firstDate.Date)
                yield break;

            var startDate = firstDate.Date.AddDays(1);
            var endDate = secondDate.Date.AddDays(-1);

            for (var rollingDate = startDate; rollingDate <= endDate; rollingDate = rollingDate.AddDays(1))
            {
                yield return rollingDate.Date;
            }
        }

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
            if (secondDate.Date <= firstDate.Date)
                return 0;

            var days = GetDaysBetweenExeclusive(firstDate, secondDate);
            return days.Count(day => day.IsBusinessDay());
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
            if (secondDate.Date <= firstDate.Date)
                return 0;

            var days = GetDaysBetweenExeclusive(firstDate, secondDate);
            var isHoliday = new Func<DateTime, bool>(day => publicHolidays.Any(holiday => day.Date == holiday.Date));
            return days.Count(day => day.IsBusinessDay() && !isHoliday(day));
        }
    }
}
