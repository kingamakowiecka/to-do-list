using System;

namespace ToDoList.Util
{
   public class DateTimeHelper
    {
        public static DateTime RemoveSecondsFromDateTime(DateTime date)
        {
            date = date.AddTicks(-(date.Ticks % TimeSpan.TicksPerMinute));
            return date;
        }
    }
}
