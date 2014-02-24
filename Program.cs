using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BusinessDayCounting.Holidays;

namespace BusinessDayCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            /// TASK 1: Weekday counting

            // Monday 07-Oct-2013 and Wednesday 09-Oct-2013 : should return 1
            int value1 = BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9));
            Debug.Assert(value1 == 1);

            // Saturday 05-Oct-2013 and Monday 14-Oct-2013 : should return 5
            int value2 = BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14));
            Debug.Assert(value2 == 5);

            // Monday 07-Oct-2013 and Wednesday 01-Jan-2014 : should return 61
            int value3 = BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1));
            Debug.Assert(value3 == 61);

            // Monday 07-Oct-2013 and Saturday 05-Oct-2013 : should return 0 (second date earlier than first date)
            int value4 = BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5));
            Debug.Assert(value4 == 0);

            
            /// TASK 2: Business day counting

            // Public holiday list containing Christmas Day, Boxing Day and New Year's Day
            List<DateTime> publicHolidays = new List<DateTime> 
            {
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26), 
                new DateTime(2014, 1, 1) 
            };

            // Monday 07-Oct-2013 and Wednesday 09-Oct-2013 : should still return 1
            int value5 = BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), publicHolidays);
            Debug.Assert(value5 == 1);

            // Tuesday 24-Dec-2013 and Friday 27-Dec-2013 : should return 0, both days are public holidays
            int value6 = BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), publicHolidays);
            Debug.Assert(value6 == 0);

            // Monday 07-Oct-2013 and Wednesday 01-Jan-2014 : should return 59
            int value7 = BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), publicHolidays);
            Debug.Assert(value7 == 59);

            // test a fixed date recurrance holiday
            var fixedRecurranceHoliday = new Holiday(new DateTime(1981, 8, 15), 3);
            var value8 = fixedRecurranceHoliday.GetForYear(2014);
            Debug.Assert(value8.Count() == 3 && value8.First() == new DateTime(2014, 8, 15) && value8.All(d => d.IsBusinessDay()));

            // test a specific day of week/month annual recurrance holiday
            var variable_reccurance = new DayOfWeekAnnualReccurance(DayOfWeek.Thursday, WeekOfMonth.SecondWeek, Month.August);
            var variableRecurranceHoliday = new Holiday(new DateTime(1981, 8, 18), 3, variable_reccurance);
            var value9 = variableRecurranceHoliday.GetForYear(2014);
            Debug.Assert(value9.Count() == 3 && value9.First() == new DateTime(2014, 8, 14));

        }
    }
}
